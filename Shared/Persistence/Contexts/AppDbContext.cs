using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace si730ebu20201b980.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Reward> Rewards { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Rewards
        builder.Entity<Reward>().ToTable("Rewards");
        builder.Entity<Reward>().HasKey(p => p.Id);
        builder.Entity<Reward>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reward>().Property(p => p.FleetId).IsRequired();
        builder.Entity<Reward>().Property(p => p.Name).IsRequired();
        builder.Entity<Reward>().Property(p => p.Description).IsRequired(false);
        builder.Entity<Reward>().Property(p => p.Score).IsRequired();
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}