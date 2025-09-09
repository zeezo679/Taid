using Demo.Models.Entities;

namespace Demo.Models.Interfaces
{
    public interface IDepartmentRepository
    {
        List<Department> Load();
        Department Get(int id);
        void Insert(Department department);
        void Update(int id, Department newDepartment);
        void Delete(int id);
    }
}
