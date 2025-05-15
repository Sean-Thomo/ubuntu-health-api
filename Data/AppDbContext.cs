using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ubuntu_health_api.Models;

namespace ubuntu_health_api.Data
{
  public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
  {
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<ClinicalNote> ClinicalNotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // ------ Patient ------
      modelBuilder.Entity<Patient>(entity =>
      {
        entity.HasIndex(p => p.TenantId);
        entity.HasIndex(p => p.IdNumber);
      });

      // ------ Appointment ------
      modelBuilder.Entity<Appointment>(entity =>
      {
        entity.HasKey(a => a.Id);
        entity.HasIndex(a => new { a.TenantId });
        entity.HasOne(a => a.Patient)
              .WithMany(p => p.Appointments)
              .OnDelete(DeleteBehavior.Cascade);
      });

      // ------ ClinicalNote ------
      modelBuilder.Entity<ClinicalNote>(entity =>
      {
        entity.HasOne(c => c.Patient)
              .WithMany(p => p.ClinicalNotes)
              .HasForeignKey(c => c.PatientId)
              .OnDelete(DeleteBehavior.Cascade);
      });

      // ------ Prescription ------
      modelBuilder.Entity<Prescription>(entity =>
      {
        entity.HasOne(p => p.Patient)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
      });

      // ------ Invoice ------
      modelBuilder.Entity<Invoice>(entity =>
      {
        entity.HasOne(i => i.Patient)
            .WithMany(p => p.Invoices)
            .HasForeignKey(i => i.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
      });
    }
  }
}