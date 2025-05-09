using ubuntu_health_api.Models;
using ubuntu_health_api.Data;
using Microsoft.EntityFrameworkCore;

namespace ubuntu_health_api.Repositories
{
  public class AppointmentRepository(AppDbContext context) : IAppointmentRepository
  {
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(string tenantId)
    {
      return await _context.Appointments.Where(a => a.TenantId == tenantId).ToListAsync();
    }

    public async Task<Appointment> GetAppointmentByIdAsync(int id, string tenantId)
    {
      var appointment = await _context.Appointments.FirstOrDefaultAsync(
        a => a.AppointmentId == id && a.TenantId == tenantId) ??
        throw new KeyNotFoundException(
          $"Appointment with ID {id} and Tenant ID {tenantId} was not found.");
      return appointment;
    }

    public async Task AddAppointmentAsync(Appointment appointment)
    {
      await _context.Appointments.AddAsync(appointment);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAppointmentAsync(int id)
    {
      var appointment = await _context.Appointments.FindAsync(id);
      if (appointment != null)
      {
        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
      }
    }

    public async Task UpdateAppointmentAsync(Appointment appointment)
    {
      _context.Appointments.Update(appointment);
      await _context.SaveChangesAsync();
    }
  }
}