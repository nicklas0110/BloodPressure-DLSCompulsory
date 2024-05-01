using MeasurementService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeasurementService.Core.Repositories;

public class MeasurementDbContext : DbContext
{
    public MeasurementDbContext(DbContextOptions<MeasurementDbContext> options) : base(options)
    { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=measurement-db;Database=MeasurementDb;User Id=sa;Password=uhohst1nky!;Trusted_Connection=False;TrustServerCertificate=True;");        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Core.Entities.Measurement>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

    }

    public DbSet<Core.Entities.Measurement> Measurements { get; set; }
}