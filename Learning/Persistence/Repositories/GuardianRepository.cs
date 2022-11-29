using si730ebu20201b980.API.Learning.Domain.Models;
using si730ebu20201b980.API.Learning.Domain.Repositories;
using si730ebu20201b980.API.Shared.Persistence.Contexts;
using si730ebu20201b980.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace si730ebu20201b980.API.Learning.Persistence.Repositories;

public class GuardianRepository : BaseRepository, IGuardianRepository
{
    public GuardianRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Guardian>> ListAsync()
    {
        return await _context.Guardians.Include(p=>p.Urgencies).ToListAsync();
    }

    public async Task AddAsync(Guardian guardian)
    {
        await _context.Guardians.AddAsync(guardian);
    }

    public async Task<Guardian> FindByIdAsync(int id)
    {
        return (await _context.Guardians.Include(p=>p.Urgencies).FirstOrDefaultAsync(p => p.Id == id))!;
    }

    public void Update(Guardian guardian)
    {
        _context.Guardians.Update(guardian);
    }

    public void Remove(Guardian guardian)
    {
        _context.Guardians.Remove(guardian);
    }
}