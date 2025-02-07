using FullStackMon.Models;

namespace FullStackMon.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        //BL Departent (CRUD) Create - REad -Update -Delete
        ITIContext context;

        public string Id {get;set; }
        //di pattern dont create but inject or ask
        public DepartmentRepository(ITIContext ctx)//when create object
        {
            context =ctx;
            //id unique id
            Id= Guid.NewGuid().ToString();
        }
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }
        public Department GetById(int id) {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }
        public void Add(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Remove(dept);
        }
        public int Save()
        {
            return context.SaveChanges();
        }

    }
}
