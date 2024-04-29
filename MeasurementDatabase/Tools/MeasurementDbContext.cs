using MeasurementDatabase.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeasurementDatabase.Tools;

public class MeasurementDbContext : DbContext
{
    public DbSet<Measurement> Measurements { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=Measurements;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
    
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TODO noget skal ændres her
        modelBuilder.Entity<Measurement>().Property(m => m.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Measurement>().HasIndex(m => m.DateTaken).IsUnique();
    }
}