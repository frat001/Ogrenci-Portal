using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentPortal_Core.DTO_s.TeacherDTO;
using StudentPortal_Core.Entities.Concrete;
using StudentPortal_DataAccess.Services.Interface;
using StudentPortal_WEB.Models.ViewModels;
using StudentPortal_Core.Entities.Abstract;

namespace StudentPortal_WEB.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository teacherRepo, IMapper mapper)
        {
            _teacherRepo = teacherRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherRepo.GetFilteredListAsync
                (
                    select: x => new GetTeacherVM
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        Status = x.Status
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                );

            return View(teachers);
        }

        public IActionResult CreateTeacher() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeacher(CreateTeacherDTO model)
        {
            if (ModelState.IsValid)
            {
                var teacher = _mapper.Map<Teacher>(model);
                await _teacherRepo.AddAsync(teacher);
                TempData["Success"] = $"{teacher.FirstName} {teacher.LastName} öğretmeni sisteme kaydedilmiştir.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> UpdateTeacher(int id)
        {
            if (id > 0)
            {
                var teacher = await _teacherRepo.GetByIdAsync(id);

                if (teacher is not null)
                {
                    var model = _mapper.Map<UpdateTeacherDTO>(teacher);
                    return View(model);
                }
            }
            TempData["Error"] = "Öğretmen bulunamadı!";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherDTO model)
        {
            if (ModelState.IsValid)
            {
                var teacher = _mapper.Map<Teacher>(model);
                await _teacherRepo.UpdateAsync(teacher);
                TempData["Success"] = $"{teacher.FirstName} {teacher.LastName} kişisi güncellendi!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            if (id > 0)
            {
                var teacher = await _teacherRepo.GetByIdAsync(id);
                if (teacher is not null)
                {
                    if (!await _teacherRepo.HasClassroom(id))
                    {
                        await _teacherRepo.DeleteAsync(teacher);
                        TempData["Success"] = $"{teacher.FirstName} {teacher.LastName} hocamıza hizmetleri için teşekkür ederiz. Hocamız silinmiştir.";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var classroomList = await _teacherRepo.ClassroomNames(teacher.Id);
                        TempData["Error"] = $"{teacher.FirstName} {teacher.LastName} hoca şu sınıflarda kayıtlıdır => {classroomList}";
                        return RedirectToAction("Index");
                    }
                }
            }
            TempData["Error"] = "Hoca bulunamadı!";
            return RedirectToAction("Index");
        }
    }
}
