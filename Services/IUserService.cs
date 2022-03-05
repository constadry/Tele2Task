using Tele2Task.Communication;
using Tele2Task.Models;

namespace Tele2Task.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();  
    Task<UserResponse> Get(int id);
    Task<UserResponse> Save(User user);
    Task<UserResponse> Update(User user);
    Task<UserResponse> Delete(int id);
}