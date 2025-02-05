using FullStackMon.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackMon.ViewModel
{
    public class EmployeeWithDepartmentsListViewModel
    {
        public int Id { get; set; }

        [Display(Name="Emp Name")]
        //[DataType(DataType.Password)]//1)
        public string Name { get; set; }//2)
       
        public int Salary { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
        public string? JobTitle { get; set; }
        public int DepartmentId { get; set; }

        public List<Department> DepartmentList { get; set; }
    }
}
