using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hospital.Domain;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acceso> Accesos { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Consulta> Consultas { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=hospital-db.database.windows.net;Database=hospital_db;User=administrador;Password='hospital_1234;';TrustServerCertificate=true;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceso>(entity =>
        {
            entity.ToTable("Acceso");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasOne(d => d.Doctor).WithMany(p => p.Cita)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasOne(d => d.Cita).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.CitaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.ToTable("Especialidad");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.ToTable("Hospital");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("Paciente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
