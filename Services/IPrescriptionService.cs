using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Services
{
  public interface IPrescriptionService
  {
    Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync(string tenantId);
    Task<PrescriptionDto> GetPrescriptionByIdAsync(int id, string tenantId);
    Task AddPrescriptionAsync(Prescription prescription, string tenantId);
    Task<bool> DeletePrescriptionAsync(int id, string tenantId);
    Task<bool> UpdatePrescriptionAsync(Prescription prescription, string tenantId);
  }
}