using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Tele2Task.Contexts;
using Tele2Task.Models;
using Tele2Task.Tools;

namespace Tele2Task.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        Debug.Assert(Context.Users != null, "Context.Users != null");
        return await Context.Users.ToListAsync();
    }

    public async Task<User> Get(string id)
    {
        Debug.Assert(Context.Users != null, "Context.Users != null");
        return await Context.Users.FindAsync(id) ??
               throw new Tele2Exception($"User not found by id {id}");
    }

    public async Task<User> Save(User entity)
    {
        Debug.Assert(Context.Users != null, "Context.Users != null");
        var result = await Context.Users.AddAsync(entity);
        return result.Entity;
    }

    public async Task<User> Update(User entity)
    {
        var user = await Get(entity.UserId);
        user.Name = entity.Name;
        user.Sex = entity.Sex;
        return user;
    }

    public async Task<User> Delete(User entity)
    {
        Debug.Assert(Context.Users != null, "Context.Users != null");
        var result = Context.Users.Remove(entity);
        return result.Entity;
    }
}