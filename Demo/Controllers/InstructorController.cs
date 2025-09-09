using Demo.Infrastructure;
using Demo.Models.Entities;
using Demo.Models.Interfaces;
using Demo.Models.Repository;
using Demo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Demo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InstructorController : Controller
    {

        private ICourseRepository CourseRepository;
        private IInstructorRepository InstructorRepository;
        private IDepartmentRepository DepartmentRepository;

        public InstructorController(
            ICourseRepository courseRepository, 
            IInstructorRepository instructorRepository,
            IDepartmentRepository departmentRepository
            )
        {
            CourseRepository = courseRepository;
            InstructorRepository = instructorRepository;
            DepartmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            List<Instructor> instructors = InstructorRepository.Load();

            return View(instructors);

        }

        public IActionResult GetInstructor(int id)
        {
            List<Instructor> instructors = InstructorRepository.Load();

            var instructor = InstructorRepository.Get(id);

            return View(instructor);
        }

        public IActionResult Edit(int id)
        {
            List<Instructor> instructors = InstructorRepository.Load();
            var instructor = InstructorRepository.Get(id);
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Instructor newInstructor)
        {
            List<Instructor> instructors = InstructorRepository.Load();
            var oldInstructor = InstructorRepository.Get(newInstructor.Id);

            if(newInstructor is null)
                return RedirectToAction("Edit");

            if (newInstructor.Name == null || newInstructor.Image == null)
                return RedirectToAction("Edit");

            InstructorRepository.Update(oldInstructor, newInstructor);
            //InstructorRepository.Update(newInstructor.Id, oldInstructor);

            TempData["success"] = true;
            return RedirectToAction("Index");
        }


        public IActionResult addInstructor()
        {
            List<Course> courses = CourseRepository.Load();
            List<Department> departments = DepartmentRepository.Load();

            var instructorVm = new InstructorViewModel();
            instructorVm.courses = courses;
            instructorVm.departments = departments;

            return View(instructorVm);
        }
         
        public IActionResult SuccessAdd(InstructorViewModel newInstructorvm)
        {

            var newInstructor = new Instructor
            {
                Id = newInstructorvm.Id,
                Name = newInstructorvm.Name,
                Image = newInstructorvm.Image,
                Salary = newInstructorvm.Salary,
                Address = newInstructorvm.Address,
                CourseId = newInstructorvm.CourseId,
                DeptId = newInstructorvm.DeptId,
                Course = newInstructorvm.Course,
                Department = newInstructorvm.Department,
            };


            var department = DepartmentRepository.Get(newInstructor.DeptId);

            newInstructor.Department = department;
            InstructorRepository.Insert(newInstructor);
            TempData["success"] = true;

            return RedirectToAction("Index");
        }

        //creating action to show the courses for that depeartment
        public IActionResult ShowCoursesPerDept(int deptId)
        {
            var department = DepartmentRepository.Get(deptId);
            var allCourses = CourseRepository.Load();


            var itemList = allCourses.Where(c => c.DeptId == deptId).ToList();

            var ivm = new InstructorViewModel
            {
                itemList = itemList,
            };
            
            return PartialView("ShowCoursesPerDeptPartial",ivm);
        }

        public IActionResult ShowSuccess()
        {
            return View("_ShowSuccessPartial");
        }
    }
}

//goal - display the courses for the selected department using ajax