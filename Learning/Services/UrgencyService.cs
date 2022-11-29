using si730ebu20201b980.API.Learning.Domain.Models;
using si730ebu20201b980.API.Learning.Domain.Repositories;
using si730ebu20201b980.API.Learning.Domain.Services;
using si730ebu20201b980.API.Learning.Domain.Services.Communication;
using si730ebu20201b980.API.Shared.Domain.Repositories;

namespace si730ebu20201b980.API.Learning.Services;

public class UrgencyService: IUrgencyService
{
    private readonly IUrgencyRepository _urgencyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UrgencyService(IUrgencyRepository urgencyRepository, IUnitOfWork unitOfWork)
    {
        _urgencyRepository = urgencyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Urgency>> ListAsync()
    {
        return await _urgencyRepository.ListAsync();
    }

    public async Task<IEnumerable<Urgency>> ListByGuardianIdAsync(int guardianId)
    {
        return await _urgencyRepository.ListByGuardianIdAsync(guardianId);
    }

    public Task<Urgency> FindByIdAsync(int id)
    {
        var urgency = _urgencyRepository.FindByIdAsync(id);
        return urgency;
    }

    public async Task<UrgencyResponse> SaveAsync(Urgency urgency)
    {
        try
        {
            await _urgencyRepository.AddAsync(urgency);
            await _unitOfWork.CompleteAsync();
            return new UrgencyResponse(urgency);
        }
        catch (Exception e)
        {
            return new UrgencyResponse($"An error occurred when saving the urgency: {e.Message}");
        }
    }

    public async Task<UrgencyResponse> UpdateAsync(int id, Urgency urgency)
    {
        var existingUrgency = await _urgencyRepository.FindByIdAsync(id);
        if (existingUrgency == null)
            return new UrgencyResponse("Urgency not found.");
        existingUrgency.Title = urgency.Title;
        existingUrgency.Summary = urgency.Summary;
        existingUrgency.Latitude= urgency.Latitude;
        existingUrgency.Longitude= urgency.Longitude;
        existingUrgency.ReportedAt= urgency.ReportedAt;
        try
        {
            _urgencyRepository.Update(existingUrgency);
            await _unitOfWork.CompleteAsync();
            return new UrgencyResponse(existingUrgency);
        }
        catch (Exception e)
        {
            return new UrgencyResponse($"An error occurred when updating the urgency: {e.Message}");
        }

    }

    public async Task<UrgencyResponse> DeleteAsync(int id)
    {
        var existingUrgency = await _urgencyRepository.FindByIdAsync(id);
        if (existingUrgency == null)
            return new UrgencyResponse("Urgency not found.");
        try
        {
            _urgencyRepository.Remove(existingUrgency);
            await _unitOfWork.CompleteAsync();
            return new UrgencyResponse(existingUrgency);
        }
        catch (Exception e)
        {
            return new UrgencyResponse($"An error occurred when deleting the urgency: {e.Message}");
        }
    }
    
    public async Task<UrgencyResponse> DeleteByGuardianIdAsync(int guardianId)
    {
        var existingUrgency = await _urgencyRepository.ListByGuardianIdAsync(guardianId);
        if (existingUrgency == null)
            return new UrgencyResponse("Urgencies not found.");
        try
        {
            _urgencyRepository.RemoveByGuardianId(guardianId);
            await _unitOfWork.CompleteAsync();
            return new UrgencyResponse("Urgencies deleted.");
        }
        catch (Exception e)
        {
            return new UrgencyResponse($"An error occurred when deleting the urgencies: {e.Message}");
        }
    }
}