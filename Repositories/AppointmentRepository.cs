using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentRepository>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointment.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}