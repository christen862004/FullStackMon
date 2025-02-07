using FullStackMon.Models;

namespace FullStackMon.Repository
{
    public class EmpMemeoryREposirory : IEmployeeRepository
    {
        List<Employee> Employees = new List<Employee>();
        public EmpMemeoryREposirory()
        {
            Employees.Add(new Employee() { Id = 1, Name = "ahmed" });
            Employees.Add(new Employee() { Id = 2, Name = "Eman" });
            Employees.Add(new Employee() { Id = 3, Name = "serag" });
        }

        public List<Employee> GetAll()
        {
            return Employees;
        }



        public void Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
       

        public List<Employee> GetByDeptId(int deptId)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
