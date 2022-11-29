namespace si730ebu20201b980.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}