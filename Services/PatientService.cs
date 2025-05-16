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
      var patient = await _patientRepository.GetPatientByIdAsync(id, tenantId) ??
      throw new KeyNotFoundException("Patient not found.");
      return _mapper.Map<PatientDto>(patient);
    }

    public async Task<PatientDto> AddPatientAsync(PatientDto createDto, string tenantId)
    {
      var patient = _mapper.Map<Patient>(createDto);
      patient.TenantId = tenantId;
      patient.CreatedAt = DateTime.UtcNow;
      patient.UpdatedAt = DateTime.UtcNow;

      await _patientRepository.AddPatientAsync(patient);

      return _mapper.Map<PatientDto>(patient);
    }

    public async Task<PatientDto> UpdatePatientAsync(int id, PatientDto updateDto, string tenantId)
    {
      var existingPatient = await _patientRepository.GetPatientByIdAsync(id, tenantId)
        ?? throw new KeyNotFoundException("Patient not found");

      _mapper.Map(updateDto, existingPatient);
      await _patientRepository.UpdatePatientAsync(existingPatient, tenantId);
      return _mapper.Map<PatientDto>(existingPatient);
    }

    public async Task<bool> DeletePatientAsync(int id, string tenantId)
    {
      var patient = await _patientRepository.GetPatientByIdAsync(id, tenantId);
      if (patient == null)
      {
        return false;
      }
      await _patientRepository.DeletePatientAsync(id, tenantId);
      return true;
    }
  }
}