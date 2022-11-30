using si730ebu20201b980.API.Loyalty.Domain.Models;

namespace si730ebu20201b980.API.Loyalty.Domain.Repositories;

public interface IRewardRepository
{
    Task<IEnumerable<Reward>> ListByScoreAsync(decimal score);
    Task<IEnumerable<Reward>> ListByFleetIdAsync(int fleetId);
    Task AddAsync(Reward reward);
}