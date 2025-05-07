using ubuntu_health_api.Data;
using ubuntu_health_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ubuntu_health_api.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(string tenantId)
        {
            return await _context.Patients.Where(p => p.TenantId == tenantId).ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id, string tenantId)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == id && p.TenantId == tenantId) ?? throw new KeyNotFoundException($"Patient with ID {id} and Tenant ID {tenantId} was not found.");
            return patient;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}