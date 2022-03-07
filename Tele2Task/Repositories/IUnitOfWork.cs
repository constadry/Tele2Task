namespace Tele2Task.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}