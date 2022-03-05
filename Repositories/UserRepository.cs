using Tele2Task.Contexts;
using Tele2Task.Models;

namespace Tele2Task.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return 
    }

    public Task<User> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Save(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> Update(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> Delete(User entity)
    {
        throw new NotImplementedException();
    }
}