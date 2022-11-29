using si730ebu20201b980.API.Loyalty.Domain.Models;
namespace si730ebu20201b980.API.Loyalty.Domain.Repositories;

public interface IUrgencyRepository
{
    Task<IEnumerable<Urgency>> ListAsync();
    Task<IEnumerable<Urgency>> ListByGuardianIdAsync(int guardianId);
    Task AddAsync(Urgency urgency);
    Task<Urgency> FindByIdAsync(int id);
    void Update(Urgency urgency);
    void Remove(Urgency urgency);
    void RemoveByGuardianId(int guardianId);
}