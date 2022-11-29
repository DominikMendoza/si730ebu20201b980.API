using si730ebu20201b980.API.Learning.Domain.Models;
using si730ebu20201b980.API.Learning.Domain.Services.Communication;

namespace si730ebu20201b980.API.Learning.Domain.Services;

public interface IGuardianService
{
    Task<IEnumerable<Guardian>> ListAsync();
    Task<Guardian> FindByIdAsync(int id);
    Task<GuardianResponse> SaveAsync(Guardian guardian);
    Task<GuardianResponse> UpdateAsync(int id, Guardian guardian);
    Task<GuardianResponse> DeleteAsync(int id);
}