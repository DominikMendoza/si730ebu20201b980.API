using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Domain.Repositories;
using si730ebu20201b980.API.Shared.Persistence.Contexts;
using si730ebu20201b980.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace si730ebu20201b980.API.Loyalty.Persistence.Repositories;

public class UrgencyRepository : BaseRepository, IUrgencyRepository
{
    public UrgencyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Urgency>> ListAsync()
    {
        return await _context.Urgencies.ToListAsync();
    }
    public async Task<IEnumerable<Urgency>> ListByGuardianIdAsync(int guardianId)
    {
        return await _context.Urgencies
            .Where(p => p.GuardianId == guardianId)
            .ToListAsync();
    }
    public async Task AddAsync(Urgency urgency)
    {
        await _context.Urgencies.AddAsync(urgency);
    }

    public async Task<Urgency> FindByIdAsync(int id)
    {
        return (await _context.Urgencies.FindAsync(id))!;
    }

    public void Update(Urgency urgency)
    {
        _context.Urgencies.Update(urgency);
    }

    public void Remove(Urgency urgency)
    {
        _context.Urgencies.Remove(urgency);
    }
    
    public void RemoveByGuardianId(int guardianId)
    {
        var urgencies = _context.Urgencies.Where(p => p.GuardianId == guardianId);
        _context.Urgencies.RemoveRange(urgencies);
    }
}