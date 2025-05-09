using ubuntu_health_api.Data;
using ubuntu_health_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ubuntu_health_api.Repositories
{
  public class PatientRepository(AppDbContext dbContext) : IPatientRepository
  {
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync(string tenantId)
    {
      return await _dbContext.Patients.Where(p => p.TenantId == tenantId).ToListAsync();
    }

    public async Task<Patient> GetPatientByIdAsync(int id, string tenantId)
    {
      var patient = await _dbContext.Patients.FirstOrDefaultAsync(
        p => p.PatientId == id && p.TenantId == tenantId) ??
        throw new KeyNotFoundException(
          $"Patient with ID {id} and Tenant ID {tenantId} was not found.");
      return patient;
    }

    public async Task AddPatientAsync(Patient patient)
    {
      await _dbContext.Patients.AddAsync(patient);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePatientAsync(int id)
    {
      var patient = await _dbContext.Patients.FindAsync(id);
      if (patient != null)
      {
        _dbContext.Patients.Remove(patient);
        await _dbContext.SaveChangesAsync();
      }
    }

    public async Task UpdatePatientAsync(Patient patient)
    {
      _dbContext.Patients.Update(patient);
      await _dbContext.SaveChangesAsync();
    }
  }
}