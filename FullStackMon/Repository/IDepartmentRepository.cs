using FullStackMon.Models;

namespace FullStackMon.Repository
{
    public interface IDepartmentRepository
    {
        string Id { get; set; }//create object unique
        List<Department> GetAll();
        Department GetById(int id);
        void Add(Department obj);
        void Update(Department obj);
        void Delete(int id);
        int Save();
    }
}