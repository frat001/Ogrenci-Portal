using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal_Core.DTO_s.AccountDTO;
using StudentPortal_Core.Entities.Concrete;
using StudentPortal_Core.Entities.UserEntites.Concrete;
using StudentPortal_DataAccess.Services.Interface;
using System.Globalization;
using System.Text;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace StudentPortal_WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher, IStudentRepository studentRepository, ITeacherRepository teacherRepository, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Register()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var model = new RegisterDTO() { Roles = roles };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            model.Roles = roles;
            if (ModelState.IsValid)
            {
                var appUser = new AppUser
                {
                    UserName = String.Join("", model.FirstName.Normalize(NormalizationForm.FormD)
                    .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).ToLower().Replace('ı', 'i') + "." + String.Join("", model.LastName.Normalize(NormalizationForm.FormD)
                    .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).ToLower().Replace('ı', 'i'),
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate
                };
                appUser.PasswordHash = _passwordHasher.HashPassword(appUser, model.Password);
                IdentityResult result = await _userManager.CreateAsync(appUser);
                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByIdAsync(model.RoleId);
                    if (role.Name == "student")
                    {
                        var student = new Student
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            BirthDate = (DateTime)model.BirthDate,
                            Email = model.Email
                        };
                        await _studentRepository.AddAsync(student);

                    }

                    else if (role.Name == "teacher")
                    {
                        var teacher = new Teacher
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            BirthDate = model.BirthDate,
                            Email = model.Email

                        };
                        await _teacherRepository.AddAsync(teacher);
                    }

                    TempData["Success"] = $"Hoşgeldiniz. Giriş yapma sayfasına yönlendiriliyorsunuz...";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Error"] = "Kayıt Yapılamadı!";
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz! ";
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login() => View();

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByNameAsync(model.UserName);
                if (appUser != null)
                {
                    SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = $" Hoş geldiniz {appUser.FirstName} {appUser.LastName}";
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Kullanıcı adı veya şifre yanlış";
                return View(model);

            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz";
            return View(model);
        }

        public async Task<IActionResult> EditUser()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId is not null)
            {
                var appUser = await _userManager.FindByIdAsync(userId);
                var model = new EditUserDTO
                {
                    Id = appUser.Id,
                    BirthDate = appUser.BirthDate is not null ? appUser.BirthDate.Value.ToShortDateString() : null,
                    CreatedDate = appUser.CreatedDate,
                    UpdatedDate = appUser.UpdatedDate,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    Email = appUser.Email,
                    UserName = appUser.UserName,
                    Password = appUser.PasswordHash
                };

                return View(model);
            }
            TempData["Error"] = "Önce Giriş Yapınız";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var appUser = await _userManager.FindByIdAsync(userId);
                if (appUser != null)
                {

                    appUser.Email = model.Email;
                    if (model.Password != null)
                    {
                        appUser.PasswordHash = _passwordHasher.HashPassword(appUser, model.Password);
                    }
                    appUser.UpdatedDate = DateTime.Now;
                    appUser.Status = StudentPortal_Core.Entities.Abstract.Status.Modified;

                    var result = await _userManager.UpdateAsync(appUser);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Profiliniz güncellendi!";
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            TempData["Error"] = error.Description;
                        }
                    }
                }
            }
            else
            {
                TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                TempData["Success"] = "Başarılı bir şekilde çıkış yaptınız";
                return RedirectToAction("Login");
            }
            TempData["Error"] = "Önce Giriş Yapınız";
            return RedirectToAction("Index","Home");

        }


    }
}
