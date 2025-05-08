using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ubuntu_health_api.Models;

namespace ubuntu_health_api.Data
{
  public class AppDbContext : IdentityDbContext<ApplicationUser>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Practitioner> Practitioners { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Tenant> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Patient>()
          .HasIndex(p => p.IdNumber);

      modelBuilder.Entity<Appointment>()
          .HasIndex(a => a.AppointmentDate);

      modelBuilder.Entity<Appointment>()
          .HasIndex(a => a.AppointmentId);

      modelBuilder.Entity<Invoice>()
          .HasIndex(i => i.PatientId);
    }
  }
}