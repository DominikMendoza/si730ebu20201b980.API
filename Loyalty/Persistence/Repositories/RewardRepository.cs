using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Domain.Repositories;
using si730ebu20201b980.API.Shared.Persistence.Contexts;
using si730ebu20201b980.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace si730ebu20201b980.API.Loyalty.Persistence.Repositories;

public class RewardRepository : BaseRepository, IRewardRepository
{
    public RewardRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Reward>> ListByScoreAsync(decimal score)
    {
        return await _context.Rewards
            .Where(r => r.score >= score)
            .ToListAsync();
    }

    public async Task AddAsync(Reward reward)
    {
        await _context.Rewards.AddAsync(reward);
    }
}