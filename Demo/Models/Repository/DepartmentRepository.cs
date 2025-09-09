using Demo.Infrastructure;
using Demo.Models.Entities;
using Demo.Models.Interfaces;

namespace Demo.Models.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private AppDbContext _context = new AppDbContext();

        public DepartmentRepository(AppDbContext context) {
            _context = context;
        }
        public List<Department> Load()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }
        public Department Get(int id)
        {
            Department dept = _context.Departments.FirstOrDefault(c => c.Id == id);
            return dept;
        }
        public void Insert(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
        public void Update(int id, Department newDepartment)
        {
            var oldCrs = Get(id);
            _context.Entry(oldCrs).CurrentValues.SetValues(newDepartment);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var deletedCourse = Get(id);
            _context.Departments.Remove(deletedCourse);
            _context.SaveChanges();
        }
    }
}
