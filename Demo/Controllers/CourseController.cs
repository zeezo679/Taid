using Demo.Infrastructure;
using Demo.Models.Entities;
using Demo.Models.Interfaces;
using Demo.Models.Repository;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.Controllers;


public class CourseController : Controller
{

    private ICourseRepository CourseRepository;
    private IInstructorRepository InstructorRepository;
    private IDepartmentRepository DepartmentRepository;

    public CourseController(
        ICourseRepository courseRepository, 
        IDepartmentRepository departmentRepository,
        IInstructorRepository instructorRepository
        )
    {
        CourseRepository = courseRepository;
        DepartmentRepository = departmentRepository;
        InstructorRepository = instructorRepository;
    }

      [HttpGet]
    //[Route("courses")] -> this route has higher priority than the routing in the program.cs
    public IActionResult Index()
    {
        List<Course> courses = CourseRepository.Load();
        List<string> Errors = new List<string>();
        List<Department> departments = DepartmentRepository.Load();
        List<Instructor> instructors = InstructorRepository.Load();


        if (courses is null)
        {
            Errors.Add("Cannot fetch courses from the database");
            ViewBag.Errors = Errors;
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Departments = departments;
        ViewBag.Instructors = instructors;
        return View("Index", courses);
    }



    public IActionResult AddCourse()
    {

        CourseViewModel courseView = new CourseViewModel();

        var instructors = InstructorRepository.LoadSelectItems();

        courseView.Instructors = instructors;
        courseView.Departments = DepartmentRepository.Load();

        return View("AddCourse", courseView);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddCourse(int id,CourseViewModel CourseView)
    {
        CourseView.Departments = DepartmentRepository.Load();
        CourseView.Instructors = InstructorRepository.LoadSelectItems();

        if (ModelState.IsValid) //server side validation
        {
            try
            {
                var course = new Course
                {
                    Name = CourseView.Name,
                    Degree = CourseView.Degree,
                    MinDegree = CourseView.MinDegree,
                    DeptId = CourseView.DeptId,
                    Instructors = InstructorRepository.LoadInstructorsWithTheirCourses(CourseView, false)
                };

                int oldCourseCount = CourseRepository.Count();

                CourseRepository.Insert(course);

                int newCourseCount = CourseRepository.Count();

                if (newCourseCount > oldCourseCount)
                    TempData["Message"] = "Course Added Successfully";
                else 
                    TempData["Message"] = string.Empty;

                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        return View(CourseView);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        CourseViewModel courseView = new CourseViewModel();
        var course = CourseRepository.Get(id);


        var instructors = InstructorRepository.LoadSelectItems();

        courseView.Instructors = instructors;
        courseView.Departments = DepartmentRepository.Load();
        courseView.Name = course.Name;
        courseView.DeptId = course.DeptId;
        courseView.Id = course.Id;
        courseView.Degree = course.Degree;
        courseView.MinDegree = course.MinDegree;

        return View("Edit", courseView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, CourseViewModel newCourse)
    {
        var oldCourse = CourseRepository.Get(id);

        newCourse.Departments = DepartmentRepository.Load();
        newCourse.Instructors = InstructorRepository.LoadSelectItems();

        oldCourse.Name = newCourse.Name;
        oldCourse.DeptId = newCourse.DeptId;
        oldCourse.Degree = newCourse.Degree;
        oldCourse.MinDegree = newCourse.MinDegree;
        oldCourse.Instructors = InstructorRepository.LoadInstructorsWithTheirCourses(newCourse, true);

        return RedirectToAction("Index");
    }

    public JsonResult IsValidMinDegree(decimal minDegree, decimal degree)
    {
        if(minDegree < degree)
            return Json(true);
        else
            return Json("Minimum Degree must be less than the degree you entered");
    }

    [HttpGet]
    public IActionResult CourseDetails(int id)
    {
        var course = CourseRepository.Get(id);
        var instructors = InstructorRepository.Load();
        
        course.Instructors = instructors;

        return PartialView("CourseDetailsPartial", course);
    }
}
