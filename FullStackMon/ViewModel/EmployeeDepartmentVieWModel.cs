using FullStackMon.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace FullStackMon.ViewModel
{
    public class EmployeeDepartmentVieWModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
