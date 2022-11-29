using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Domain.Services.Communication;

namespace si730ebu20201b980.API.Loyalty.Domain.Services;

public interface IRewardService
{
    Task<IEnumerable<Reward>> ListByScoreAsync(decimal score);
    Task<Reward> SaveAsync(Reward reward);
}