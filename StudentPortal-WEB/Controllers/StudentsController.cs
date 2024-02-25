using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal_Core.DTO_s.ClassroomDTO;
using StudentPortal_Core.DTO_s.StudentDTO;
using StudentPortal_Core.Entities.Concrete;
using StudentPortal_DataAccess.Services.Interface;
using StudentPortal_WEB.Models.ViewModels;
using StudentPortal_Core.Entities.Abstract;

namespace StudentPortal_WEB.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly IClassroomRepository _classroomRepo;
        private readonly ITeacherRepository _teacherRepo;

        public StudentsController(IStudentRepository studentRepo, IMapper mapper, IClassroomRepository classroomRepo, ITeacherRepository teacherRepo)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
            _classroomRepo = classroomRepo;
            _teacherRepo = teacherRepo;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepo.GetFilteredListAsync
                (
                    select: x => new GetStudentVM
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        BirthDate = x.BirthDate,
                        Email = x.Email,
                        ClassroomName = x.Classroom.ClassroomName,
                        Average = x.Average,
                        TeacherName = x.Classroom.Teacher.FirstName + " " + x.Classroom.Teacher.LastName,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        Status = x.Status
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(z => z.CreatedDate),
                    join: x => x.Include(z => z.Classroom).ThenInclude(z => z.Teacher)
                );

            return View(students);
        }

        public async Task<IActionResult> DetailStudent(int id)
        {
            if (id > 0)
            {
                var student = await _studentRepo.GetByIdAsync(id);
                if (student is not null)
                {
                    var model = _mapper.Map<GetStudentDetailDTO>(student);
                    var classroom = await _classroomRepo.GetByIdAsync(student.ClassroomId);
                    var teacher = await _teacherRepo.GetByIdAsync(classroom.TeacherId);
                    model.ClassroomName = classroom.ClassroomName;
                    model.TeacherName = teacher.FirstName + " " + teacher.LastName;
                    return View(model);
                }
            }
            TempData["Error"] = "Öğrenci bulunamadı!";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CreateStudent()
        {
            var classrooms = await _classroomRepo.GetFilteredListAsync
                 (
                     select: x => new ShowClassroomDTO
                     {
                         Id = x.Id,
                         ClassroomName = x.ClassroomName,
                         ClassroomDescription = x.ClassroomDescription,
                         ClassroomSize = x.Students.Where(x => x.Status != Status.Passive).ToList().Count,
                         TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName
                     },
                     where: x => x.Status != Status.Passive,
                     join: x => x.Include(z => z.Students).Include(z => z.Teacher)
                 );

            var model = new CreateStudentDTO
            {
                Classrooms = classrooms
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent(CreateStudentDTO model)
        {
            var classrooms = await _classroomRepo.GetFilteredListAsync
                (
                   select: x => new ShowClassroomDTO
                   {
                       Id = x.Id,
                       ClassroomName = x.ClassroomName,
                       ClassroomDescription = x.ClassroomDescription,
                       ClassroomSize = x.Students.Where(x => x.Status != Status.Passive).ToList().Count,
                       TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName
                   },
                     where: x => x.Status != Status.Passive,
                     join: x => x.Include(z => z.Students).Include(z => z.Teacher)
                );

            model.Classrooms = classrooms;


            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(model);
                await _studentRepo.AddAsync(student);
                TempData["Success"] = $"{student.FirstName} {student.LastName} öğrencisi siteme kaydedilmiştir. Hayırlı olsun :)";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> UpdateStudent(int id)
        {
            if (id > 0)
            {
                var student = await _studentRepo.GetByIdAsync(id);
                if (student is not null)
                {
                    var model = _mapper.Map<UpdateStudentDTO>(student);
                    var classrooms = await _classroomRepo.GetFilteredListAsync
                                       (
                                          select: x => new ShowClassroomDTO
                                          {
                                              Id = x.Id,
                                              ClassroomName = x.ClassroomName,
                                              ClassroomDescription = x.ClassroomDescription,
                                              ClassroomSize = x.Students.Where(x => x.Status != Status.Passive).ToList().Count,
                                              TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName
                                          },
                                          where: x => x.Status != Status.Passive,
                                          join: x => x.Include(z => z.Students).Include(z => z.Teacher)
                                       );
                    model.Classrooms = classrooms;
                    return View(model);
                }
            }
            TempData["Error"] = "Öğrenci bulunamadı!";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDTO model)
        {
            var classrooms = await _classroomRepo.GetFilteredListAsync
                                       (
                                          select: x => new ShowClassroomDTO
                                          {
                                              Id = x.Id,
                                              ClassroomName = x.ClassroomName,
                                              ClassroomDescription = x.ClassroomDescription,
                                              ClassroomSize = x.Students.Where(x => x.Status != Status.Passive).ToList().Count,
                                              TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName
                                          },
                                          where: x => x.Status != Status.Passive,
                                          join: x => x.Include(z => z.Students).Include(z => z.Teacher)
                                       );
            model.Classrooms = classrooms;
            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(model);
                await _studentRepo.UpdateAsync(student);
                TempData["Success"] = $"{student.FirstName} {student.LastName} öğrencisi güncellenmiştir.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id > 0)
            {
                var student = await _studentRepo.GetByIdAsync(id);
                if (student is not null)
                {
                    await _studentRepo.DeleteAsync(student);
                    TempData["Success"] = $"{student.FirstName} {student.LastName} öğrencisinin kaydı silinmiştir!";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Öğrenci bulunamadı!";
            return RedirectToAction("Index");
        }
    }
}
