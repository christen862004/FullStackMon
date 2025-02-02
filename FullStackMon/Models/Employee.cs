using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackMon.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
        public string? JobTitle { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }//validation error
    }
}
