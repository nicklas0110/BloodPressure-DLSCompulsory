using Microsoft.EntityFrameworkCore;
using DBEntities = PatientService.Core.Entities;

namespace PatientService.Core.Repositories;

public class PatientDbContext : DbContext
{
    public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
    { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=patient-db;Database=PatientDb;User Id=SA;Password=uhohst1nky!;Trusted_Connection=False;TrustServerCertificate=True;",
            sqlOptions => {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3, // Number of retry attempts
                    maxRetryDelay: TimeSpan.FromSeconds(30), // Maximum delay between retries
                    errorNumbersToAdd: null // Additional SQL error codes that trigger a retry
                );
            }
        );        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DBEntities.Patient>().HasKey(p => p.Ssn);

        modelBuilder.Entity<DBEntities.Patient>().HasIndex(p => p.Ssn).IsUnique();
        modelBuilder.Entity<DBEntities.Patient>().HasIndex(p => p.Mail).IsUnique();
    }


    public DbSet<Core.Entities.Patient> Patients { get; set; }
}