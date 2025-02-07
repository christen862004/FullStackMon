using FullStackMon.Models;

namespace FullStackMon.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        List<Employee> GetByDeptId(int deptId);
        void Add(Employee obj);
        void Update(Employee obj);
        void Delete(int id);
        int Save();

    }
}