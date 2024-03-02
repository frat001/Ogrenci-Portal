using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal_Core.DTO_s.AccountDTO;
using StudentPortal_Core.Entities.Concrete;
using StudentPortal_Core.Entities.UserEntites.Concrete;
using StudentPortal_DataAccess.Services.Interface;
using System.Globalization;
using System.Text;

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

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher, IStudentRepository studentRepository, ITeacherRepository teacherRepository, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _roleManager = roleManager;
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
    }
}
