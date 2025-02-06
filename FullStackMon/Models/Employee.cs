/**/
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackMon.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [Unique]//server side
        [MinLength(3,ErrorMessage ="Name Must be More than 3 char")]
        [MaxLength(10)]
        public string Name { get; set; }

        [Range(minimum: 6000,maximum: 50000,ErrorMessage ="Salary must be between 6000 to 50000")]
        [Remote("CheckSalary","Employee",AdditionalFields = "JobTitle"
            , ErrorMessage =$"Salary a must be")]
        public int Salary { get; set; }

        //.jpg |a.png
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be png or jpg ex:asd.jpg")]
        public string? ImageUrl { get; set; }
        
        public string? Address { get; set; }
        [Remote("CheckSalary","Employee",AdditionalFields = "Salary", ErrorMessage ="Salary mustbe divided by 5")]

        public string? JobTitle { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        
       // [Required]
        public Department? Department { get; set; }//validation error
    }
}
