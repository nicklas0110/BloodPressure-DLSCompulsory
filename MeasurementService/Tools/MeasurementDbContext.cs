using MeasurementService.Core.Entities;
using DBEntities = MeasurementService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeasurementService.Tools;

public class MeasurementDbContext : DbContext
{
    public DbSet<DBEntities.Measurement> Measurements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=measurement-db;Database=MeasurementDb;User Id=sa;Password=uhohst1nky!;Trusted_Connection=False;TrustServerCertificate=True;");      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DBEntities.Measurement>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<DBEntities.Measurement>().HasIndex(m => m.DateTaken).IsUnique();
    }
}