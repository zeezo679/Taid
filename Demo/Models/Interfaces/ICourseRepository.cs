using Demo.Models.Entities;

namespace Demo.Models.Interfaces
{
    public interface ICourseRepository
    {
         List<Course> Load();
         Course Get(int id);
         void Insert(Course course);
         void Update(int id, Course newCourse);
         void Delete(int id);
         int Count();
    }
}
