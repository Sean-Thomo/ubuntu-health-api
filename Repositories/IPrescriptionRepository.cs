using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IPrescriptionRepository
  {
    Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync(string tenantId);
    Task<PrescriptionDto> GetPrescriptionByIdAsync(int id, string tenantId);
    Task AddPrescriptionAsync(Prescription prescription);
    Task DeletePrescriptionAsync(int id);
    Task UpdatePrescriptionAsync(Prescription prescription);
  }
}