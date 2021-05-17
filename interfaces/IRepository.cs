using System.Collections.Generic;
namespace firstDotNetProj.interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T returbById(int id);
        void insert(T entity);
        void erase(int id);
        void update(int id, T entity);
        int nextId();
    }
}