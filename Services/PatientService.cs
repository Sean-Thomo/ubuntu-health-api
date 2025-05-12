using AutoMapper;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class PatientService(IPatientRepository patientRepository, IMapper mapper) : IPatientService
  {
    private readonly IPatientRepository _patientRepository = patientRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync(string tenantId)
    {
      var patients = await _patientRepository.GetAllPatientsAsync(tenantId);
      if (patients == null || !patients.Any())
      {
        throw new KeyNotFoundException("No patients found.");
      }
      return _mapper.Map<IEnumerable<PatientDto>>(patients);
    }

    public async Task<PatientDto> GetPatientByIdAsync(int id, string tenantId)
    {
      var patient = await _patientRepository.GetPatientByIdAsync(id, tenantId);
      if (patient == null || patient.TenantId != tenantId)
      {
        throw new KeyNotFoundException("Patient not found.");
      }
      return _mapper.Map<PatientDto>(patient);
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