using Demo.Infrastructure;
using Demo.Models.Entities;
using Demo.Models.Interfaces;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private AppDbContext _context;

        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Instructor> Load()
        {
            var instructors = _context.Instructors.Include(i => i.Course).Include(i => i.Department).ToList();
            return instructors;
        }

        public List<SelectListItem> LoadSelectItems()
        {
            var instructors = _context.Instructors.Include(i => i.Course).Include(i => i.Department).Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();

            return instructors;
        }

        public List<Instructor> LoadInstructorsWithTheirCourses(CourseViewModel CourseView, bool save)
        {
           var instructors = _context.Instructors
                .Include(i => i.Course)
                .Include(i => i.Department)
                .Where(i => CourseView.InstructorIds.Contains(i.Id)).ToList();

            if(save) _context.SaveChanges();
            return instructors;
        }

        public Instructor Get(int id)
        {
            Instructor instructor = _context.Instructors.Include(i => i.Course).Include(i => i.Department).FirstOrDefault(c => c.Id == id);
            return instructor;
        }
        public void Insert(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }
        public void Update(int id, Instructor newInstructor)
        {
            var oldInstructor = Get(id);
            oldInstructor.Name = newInstructor.Name;
            oldInstructor.Salary = newInstructor.Salary;
            oldInstructor.Address = newInstructor.Address;
            oldInstructor.Image = newInstructor.Image;
            _context.SaveChanges();
        }

        public void Update(Instructor oldInstructor, Instructor newInstructor)
        {
            oldInstructor.Name = newInstructor.Name;
            oldInstructor.Salary = newInstructor.Salary;
            oldInstructor.Address = newInstructor.Address;
            oldInstructor.Image = newInstructor.Image;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var deletedInstructor = Get(id);
            _context.Instructors.Remove(deletedInstructor);
            _context.SaveChanges();
        }

        
    }
}
