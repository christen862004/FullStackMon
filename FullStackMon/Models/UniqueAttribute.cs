using System.ComponentModel.DataAnnotations;

namespace FullStackMon.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string name = value.ToString();

            ITIContext context = new ITIContext();
           //come from request
            Employee empFromREquest =(Employee) validationContext.ObjectInstance;

            //come from Databse
            Employee empFromDb = context.Employee
                .FirstOrDefault(e => e.Name == name&&e.DepartmentId==empFromREquest.DepartmentId);


            if (empFromDb == null) {
                return ValidationResult.Success;
            }

            return new ValidationResult($"Name {name} Already Exists");
        }
    }
}
