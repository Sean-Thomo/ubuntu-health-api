using ubuntu_health_api.Models;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class PatientService : IPatientService
  {
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
      _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync(string tenantId)
    {
      return await _patientRepository.GetAllPatientsAsync(tenantId);
    }

    public async Task<Patient> GetPatientByIdAsync(int id, string tenantId)
    {
      var patient = await _patientRepository.GetPatientByIdAsync(id, tenantId);
      if (patient == null || patient.TenantId != tenantId)
      {
        throw new KeyNotFoundException("Patient not found.");
      }
      return patient;
    }

    public async Task AddPatientAsync(Patient patient, string tenantId)
    {
      patient.TenantId = tenantId;
      await _patientRepository.AddPatientAsync(patient);
    }

    public async Task<bool> DeletePatientAsync(int id, string tenantId)
    {
      var patient = await _patientRepository.GetPatientByIdAsync(id, tenantId);
      if (patient == null || patient.TenantId != tenantId)
      {
        return false;
      }
      await _patientRepository.DeletePatientAsync(id);
      return true;
    }

    public async Task<bool> UpdatePatientAsync(Patient patient, string tenantId)
    {
      var existingPatient = await _patientRepository.GetPatientByIdAsync(patient.PatientId, tenantId);
      if (existingPatient == null || existingPatient.TenantId != tenantId)
      {
        return false;
      }

      patient.TenantId = tenantId;
      await _patientRepository.UpdatePatientAsync(patient);
      return true;
    }
  }
}