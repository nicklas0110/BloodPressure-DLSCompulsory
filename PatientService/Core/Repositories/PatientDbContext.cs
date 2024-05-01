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
            "Server=localhost;Database=PatientDb;User Id=sa;Password=uhohst1nky!;Trusted_Connection=False;TrustServerCertificate=True;",
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
        modelBuilder.Entity<DBEntities.Patient>(entity =>
        {
            // Set the SSN as the primary key
            entity.HasKey(p => p.Ssn);

            // Ensure SSN is not auto-generated, as it is assigned by the user
            entity.Property(p => p.Ssn)
                .ValueGeneratedNever();

            modelBuilder.Entity<DBEntities.Patient>().HasData(
                new DBEntities.Patient()
                    { Ssn = 1010101010, Mail = "g.g@gmail.com", Name = "John Doe" });
        });
    }

    public DbSet<DBEntities.Patient> Patients { get; set; }
}