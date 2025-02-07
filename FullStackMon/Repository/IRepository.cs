using FullStackMon.Models;

namespace FullStackMon.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        int Save();
    }
    //public class REposity<T> : IRepository<T> where T:class
    //{
    //    public void Add(T obj)
    //    {
    //        context.Add(obj);
    //    }

    //    public void Delete(int id)
    //    {
            
    //    }
    //    ITIContext context;
    //    public List<T> GetAll()
    //    {
    //       return  context.Set<T>().ToList();
    //    }

    //    public T GetById(int id)
    //    {
    //       return  context.Set<T>().Find(id);

    //    }

    //    public int Save()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(T obj)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
