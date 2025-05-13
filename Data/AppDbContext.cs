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
        entity.HasIndex(a => new { a.TenantId, a.PatientId });
      })

      modelBuilder.Entity<Appointment>()
          .HasIndex(a => a.AppointmentId);

      modelBuilder.Entity<Invoice>()
          .HasIndex(i => i.PatientId);
    }
  }
}