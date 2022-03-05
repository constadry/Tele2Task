using Tele2Task.Contexts;

namespace Tele2Task.Repositories;

public abstract class BaseRepository
{
    protected readonly AppDbContext Context;

    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }
}