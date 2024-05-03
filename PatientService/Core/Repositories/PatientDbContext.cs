using Microsoft.EntityFrameworkCore;
using PatientService.Core.Entities;

namespace PatientService.Core.Repositories;

public class PatientDbContext : DbContext
{
    public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
    { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=patient-db;Database=PatientDb;User Id=SA;Password=uhohst1nky!;Trusted_Connection=False;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().HasKey(c => c.Ssn);
        
        modelBuilder.Entity<Patient>().Property(p => p.Ssn).ValueGeneratedNever();
        modelBuilder.Entity<Patient>().HasIndex(p => p.Ssn).IsUnique();
        modelBuilder.Entity<Patient>().HasIndex(p => p.Mail).IsUnique();
    }

    public DbSet<Patient> Patients { get; set; }
}
