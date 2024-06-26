﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientService.Core.Repositories;

#nullable disable

namespace PatientService.Migrations
{
    [DbContext(typeof(PatientDbContext))]
    partial class PatientDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PatientService.Core.Entities.Patient", b =>
                {
                    b.Property<string>("Ssn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ssn");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.HasIndex("Ssn")
                        .IsUnique();

                    b.ToTable("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
