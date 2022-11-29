using si730ebu20201b980.API.Learning.Domain.Models;
namespace si730ebu20201b980.API.Learning.Domain.Repositories;

public interface IGuardianRepository
{
    Task<IEnumerable<Guardian>> ListAsync();
    Task AddAsync(Guardian guardian);
    Task<Guardian> FindByIdAsync(int id);
    void Update(Guardian guardian);
    void Remove(Guardian guardian);
}