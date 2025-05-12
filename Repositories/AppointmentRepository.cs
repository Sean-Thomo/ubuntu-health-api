using ubuntu_health_api.Models;
using ubuntu_health_api.Data;
using Microsoft.EntityFrameworkCore;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public class AppointmentRepository(AppDbContext context) : IAppointmentRepository
  {
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync(string tenantId)
    {
      return await _context.Appointments.Where(a => a.TenantId == tenantId).Select(a => new AppointmentDto
      {
        AppointmentId = a.AppointmentId,
        PatientFirstName = a.PatientFirstName,
        PatientLastName = a.PatientLastName,
        AppointmentDate = a.AppointmentDate,
        AppointmentTime = a.AppointmentTime,
        AppointmentType = a.AppointmentType,
        Status = a.Status,
        Notes = a.Notes,
      }).ToListAsync();
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(int id, string tenantId)
    {
      var appointment = await _context.Appointments.FirstOrDefaultAsync(
        a => a.AppointmentId == id && a.TenantId == tenantId) ??
        throw new KeyNotFoundException(
          $"Appointment with ID {id} and Tenant ID {tenantId} was not found.");
      return new AppointmentDto
      {
        AppointmentId = appointment.AppointmentId,
        PatientFirstName = appointment.PatientFirstName,
        PatientLastName = appointment.PatientLastName,
        AppointmentDate = appointment.AppointmentDate,
        AppointmentTime = appointment.AppointmentTime,
        AppointmentType = appointment.AppointmentType,
        Status = appointment.Status,
        Notes = appointment.Notes,
      };
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