using Demo.Infrastructure;
using Demo.Models.Entities;
using Demo.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models.Repository
{
    //CRUD specific model
    public class CourseRepository : ICourseRepository
    {
        private AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Course> Load()
        {
            var courses = _context.Courses.Include(c => c.Department)
                .Include(c => c.Instructors).ToList();
            return courses;
        }
        public Course Get(int id)
        {
            Course course = _context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructors)
                .FirstOrDefault(c => c.Id == id);
            return course;
        }
        public void Insert(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
        public void Update(int id, Course newCourse)
        {
            var oldCrs = Get(id);
            _context.Entry(oldCrs).CurrentValues.SetValues(newCourse);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var deletedCourse = Get(id);
            _context.Courses.Remove(deletedCourse);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Courses.Count();
        }
    }
}
