using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Domain.Repositories;
using si730ebu20201b980.API.Loyalty.Domain.Services;
using si730ebu20201b980.API.Loyalty.Domain.Services.Communication;
using si730ebu20201b980.API.Shared.Domain.Repositories;

namespace si730ebu20201b980.API.Loyalty.Services;

public class GuardianService: IGuardianService
{
    private readonly IGuardianRepository _guardianRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public GuardianService(IGuardianRepository guardianRepository, IUnitOfWork unitOfWork)
    {
        _guardianRepository = guardianRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Guardian>> ListAsync()
    {
        return await _guardianRepository.ListAsync();
    }

    public Task<Guardian> FindByIdAsync(int id)
    {
        var guardian = _guardianRepository.FindByIdAsync(id);
        return guardian;
    }

    public async Task<GuardianResponse> SaveAsync(Guardian guardian)
    {
        try
        {
            await _guardianRepository.AddAsync(guardian);
            await _unitOfWork.CompleteAsync();
            return new GuardianResponse(guardian);
        }
        catch (Exception e)
        {
            return new GuardianResponse(($"An error occurred when saving the guardian: {e.Message}"));
        }
    }

    public async Task<GuardianResponse> UpdateAsync(int id, Guardian guardian)
    {
        var existingGuardian = await _guardianRepository.FindByIdAsync(id);
        if (existingGuardian == null)
            return new GuardianResponse("Guardian not found.");
        existingGuardian.UserName = guardian.UserName;
        existingGuardian.Email= guardian.Email;
        existingGuardian.FirstName = guardian.FirstName;
        existingGuardian.LastName = guardian.LastName;
        existingGuardian.Gender= guardian.Gender;
        existingGuardian.Address= guardian.Address;
        try
        {
            _guardianRepository.Update(guardian);
            await _unitOfWork.CompleteAsync();
            return new GuardianResponse(existingGuardian);
        }
        catch (Exception e)
        {
            return new GuardianResponse($"An error occurred when updating the guardian: {e.Message}");
        }
    }

    public async Task<GuardianResponse> DeleteAsync(int id)
    {
        var existingGuardian = await _guardianRepository.FindByIdAsync(id);
        if (existingGuardian == null)
            return new GuardianResponse("Guardian not found.");
        try
        {
            _guardianRepository.Remove(existingGuardian);
            await _unitOfWork.CompleteAsync();
            return new GuardianResponse(existingGuardian);
        }
        catch (Exception e)
        {
            return new GuardianResponse($"An error occurred when deleting the guardian: {e.Message}");
        }
    }
}