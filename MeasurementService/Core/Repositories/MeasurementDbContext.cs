using Microsoft.EntityFrameworkCore;
using MeasurementService.Core.Entities;

namespace MeasurementService.Core.Repositories;

public class MeasurementDbContext : DbContext
{
    public MeasurementDbContext(DbContextOptions<MeasurementDbContext> options) : base(options)
    { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=measurement-db;Database=MeasurementDb;User Id=SA;Password=uhohst1nky!;Trusted_Connection=False;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Measurement>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Measurement>()
            .Property(p => p.PatientSSN)  
            .HasColumnType("varchar(10)")  
            .IsRequired();
    }

    public DbSet<Measurement> Measurements { get; set; }
}