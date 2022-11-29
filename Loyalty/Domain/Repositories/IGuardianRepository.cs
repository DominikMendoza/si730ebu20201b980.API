using si730ebu20201b980.API.Loyalty.Domain.Models;
namespace si730ebu20201b980.API.Loyalty.Domain.Repositories;

public interface IGuardianRepository
{
    Task<IEnumerable<Guardian>> ListAsync();
    Task AddAsync(Guardian guardian);
    Task<Guardian> FindByIdAsync(int id);
    void Update(Guardian guardian);
    void Remove(Guardian guardian);
}