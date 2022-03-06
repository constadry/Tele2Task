using Tele2Task.Communication;
using Tele2Task.Models;

namespace Tele2Task.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll(UserParameters userParameters);  
    Task<UserResponse> Get(string id);
    Task<UserResponse> Save(User user);
    Task<UserResponse> Update(User user);
    Task<UserResponse> Delete(string id);
}