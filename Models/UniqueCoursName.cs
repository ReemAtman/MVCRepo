using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace MVC.Models
{
    public class UniqueCoursName: ValidationAttribute
    {
        EducationContext context = new EducationContext();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
                      
            Course course = context.courses.FirstOrDefault(c =>c.name ==  value.ToString());
            if (course == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exist");
        }
    }
}
