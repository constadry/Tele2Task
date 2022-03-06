namespace Tele2Task.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();  
    Task<T> Get(string id);
    Task<T> Save(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}