namespace Tele2Task.Repositories;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();  
    T Get(int id);
    T Save(T entity);
    T Update(T entity);
    T Delete(T entity);
}