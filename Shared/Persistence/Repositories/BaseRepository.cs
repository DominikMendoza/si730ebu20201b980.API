using si730ebu20201b980.API.Shared.Persistence.Contexts;

namespace si730ebu20201b980.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}