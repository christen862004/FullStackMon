using System.ComponentModel.DataAnnotations;

namespace FullStackMon.Models
{
    public class Department
    {
        public int Id { get; set; } //primary key ,idntity
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
