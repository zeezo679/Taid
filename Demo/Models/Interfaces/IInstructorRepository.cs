using Demo.Models.Entities;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.Models.Interfaces
{
    public interface IInstructorRepository
    {
        List<Instructor> Load();
        List<SelectListItem> LoadSelectItems();
        List<Instructor> LoadInstructorsWithTheirCourses(CourseViewModel CourseView, bool save);
        Instructor Get(int id);
        void Insert(Instructor instructor);
        void Update(int id, Instructor newInstructor);
        void Update(Instructor oldInstructor, Instructor newInstructor);
        void Delete(int id);
    }
}
