using Tele2Task.Models;

namespace Tele2Task.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll(UserParameters userParameters);  
    Task<User> Get(string id);
    Task<User> Save(User entity);
    Task<User> Update(User entity);
    Task<User> Delete(User entity);
}