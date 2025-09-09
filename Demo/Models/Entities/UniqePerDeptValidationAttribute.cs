using Demo.Infrastructure;
using Demo.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Demo.Models.Entities
{
    public class UniqePerDeptValidationAttribute : ValidationAttribute
    {
        private readonly AppDbContext _context = new AppDbContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var courseName = (string?)value;
            var instance = validationContext.ObjectInstance as CourseViewModel;
            var deptId = instance.DeptId;

            var existance = _context.Courses.Where(c => c.DeptId == deptId && c.Name == courseName);
            var count = existance.Count();

            if(count > 0)
            {
                return new ValidationResult("Course Name Must be Unique Per Department");
            } 
            return ValidationResult.Success;
        }
    }
}
