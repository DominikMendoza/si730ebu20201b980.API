using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Domain.Services.Communication;
using si730ebu20201b980.API.Loyalty.Persistence.Repositories;

namespace si730ebu20201b980.API.Loyalty.Domain.Services;

public interface IUrgencyService
{
    Task<IEnumerable<Urgency>> ListAsync();
    Task<IEnumerable<Urgency>> ListByGuardianIdAsync(int guardianId);
    Task<Urgency> FindByIdAsync(int id);
    Task<UrgencyResponse> SaveAsync(Urgency urgency);
    Task<UrgencyResponse> UpdateAsync(int id, Urgency urgency);
    Task<UrgencyResponse> DeleteAsync(int id);
    Task<UrgencyResponse> DeleteByGuardianIdAsync(int guardianId);
}