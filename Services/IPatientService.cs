using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Services
{
  public interface IPatientService
  {
    Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync(string tenantId, CancellationToken cancellationToken = default);
    Task<PatientResponseDto> GetPatientByIdAsync(int id, string tenantId, CancellationToken cancellationToken = default);
    Task<PatientResponseDto> AddPatientAsync(PatientDto patient, string tenantId, CancellationToken cancellationToken = default);
    Task<PatientResponseDto> UpdatePatientAsync(int id, PatientDto patient, string tenantId, CancellationToken cancellationToken = default);
    Task<bool> DeletePatientAsync(int id, string tenantId, CancellationToken cancellationToken = default);
  }
}