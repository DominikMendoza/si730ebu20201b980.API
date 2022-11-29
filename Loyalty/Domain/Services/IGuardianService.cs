using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Domain.Services.Communication;

namespace si730ebu20201b980.API.Loyalty.Domain.Services;

public interface IGuardianService
{
    Task<IEnumerable<Guardian>> ListAsync();
    Task<Guardian> FindByIdAsync(int id);
    Task<GuardianResponse> SaveAsync(Guardian guardian);
    Task<GuardianResponse> UpdateAsync(int id, Guardian guardian);
    Task<GuardianResponse> DeleteAsync(int id);
}