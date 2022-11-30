using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Domain.Repositories;
using si730ebu20201b980.API.Loyalty.Domain.Services;
using si730ebu20201b980.API.Loyalty.Domain.Services.Communication;
using si730ebu20201b980.API.Shared.Domain.Repositories;

namespace si730ebu20201b980.API.Loyalty.Services;

public class RewardService : IRewardService
{
    private readonly IRewardRepository _rewardRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public RewardService(IRewardRepository rewardRepository, IUnitOfWork unitOfWork)
    {
        _rewardRepository = rewardRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Reward>> ListByScoreAsync(decimal score)
    {
        return await _rewardRepository.ListByScoreAsync(score);
    }

    public async Task<IEnumerable<Reward>> ListByFleetIdAsync(int fleetId)
    {
        return await _rewardRepository.ListByFleetIdAsync(fleetId);
    }

    public async Task<RewardResponse> SaveAsync(Reward reward)
    {
        try
        {
            await _rewardRepository.AddAsync(reward);
            await _unitOfWork.CompleteAsync();
            return new RewardResponse(reward);
        }
        catch (Exception e)
        {
            return new RewardResponse($"An error occurred when saving the reward: {e.Message}");
        }
    }
}