using FullStackMon.Models;

namespace FullStackMon.Repository
{
    public class EmployeeRepository:IEmployeeRepository// IRepository<Employee>
    {
        ITIContext context;
        public EmployeeRepository(ITIContext ctx)
        {
            context = ctx;//new ITIContext();
        }
        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }
        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(e => e.Id == id);
        }
        public List<Employee> GetByDeptId(int deptId)
        {
            return context.Employee.Where(e=>e.DepartmentId == deptId).ToList();
        }
        public void Add(Employee obj)
        {
            
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Employee emp = GetById(id);
            context.Remove(emp);
        }
        public int Save()
        {
            return context.SaveChanges();
        }

    }
}
