using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebClinic;

public partial class ClinicContext : DbContext
{
    public ClinicContext()
    {
    }

    public ClinicContext(DbContextOptions<ClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientCard> PatientCards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-P8Q9NTT;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DeparmentTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.Property(e => e.DoctorName).HasMaxLength(50);
            entity.Property(e => e.DoctorSurname).HasMaxLength(50);
            entity.Property(e => e.Iddepart).HasColumnName("IDdepart");
            entity.Property(e => e.TitileJobId).HasColumnName("TitileJobID");

            entity.HasOne(d => d.IddepartNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.Iddepart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctors_Department");

            entity.HasOne(d => d.TitileJob).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.TitileJobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctors_Jobs1");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobTitleId);

            entity.Property(e => e.JobTitleId)
                .ValueGeneratedNever()
                .HasColumnName("JobTitleID");
            entity.Property(e => e.JobTitle).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.HealingPlanId).HasColumnName("HealingPlanID");
            entity.Property(e => e.PatientName).HasMaxLength(50);
            entity.Property(e => e.PatientSurname).HasMaxLength(50);
        });

        modelBuilder.Entity<PatientCard>(entity =>
        {
            entity.HasKey(e => e.CardId);

            entity.ToTable("PatientCard");

            entity.Property(e => e.CardId).HasColumnName("CardID");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.PatientCards)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientCard_Doctors");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.PatientCards)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientCard_Patients");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
