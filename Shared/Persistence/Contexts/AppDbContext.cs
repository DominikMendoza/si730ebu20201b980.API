using si730ebu20201b980.API.Learning.Domain.Models;
using si730ebu20201b980.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace si730ebu20201b980.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<Urgency> Urgencies { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Guardians
        builder.Entity<Guardian>().ToTable("Guardians");
        builder.Entity<Guardian>().HasKey(p => p.Id);
        builder.Entity<Guardian>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Guardian>().Property(p => p.UserName).IsRequired().HasMaxLength(30);
        builder.Entity<Guardian>().Property(p => p.Email).IsRequired().HasMaxLength(30);
        builder.Entity<Guardian>().Property(p => p.FirstName).HasMaxLength(60);
        builder.Entity<Guardian>().Property(p => p.LastName).HasMaxLength(60);
        builder.Entity<Guardian>().Property(p => p.Gender).IsRequired();
        builder.Entity<Guardian>().Property(p => p.Address);
        
        // Urgencies
        builder.Entity<Urgency>().ToTable("Urgencies");
        builder.Entity<Urgency>().HasKey(p => p.Id);
        builder.Entity<Urgency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Urgency>().Property(p => p.Title).IsRequired();
        builder.Entity<Urgency>().Property(p => p.Summary).IsRequired();
        builder.Entity<Urgency>().Property(p => p.Latitude).IsRequired();
        builder.Entity<Urgency>().Property(p => p.Longitude).IsRequired();
        builder.Entity<Urgency>().Property(p => p.ReportedAt).IsRequired();
        builder.Entity<Urgency>()
            .HasOne(p => p.Guardian)
            .WithMany(p => p.Urgencies)
            .HasForeignKey(p => p.GuardianId);
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}