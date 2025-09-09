using Demo.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class DegreeValueValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var CVMinstance = validationContext.ObjectInstance as CourseViewModel;
            var degree = CVMinstance.Degree;
            var minDegree = (decimal)value;

            if(minDegree >= degree)
            {
                return new ValidationResult("Min Degree Must Be Less Than Degree");
            }
            return ValidationResult.Success;
        }
    }
}
