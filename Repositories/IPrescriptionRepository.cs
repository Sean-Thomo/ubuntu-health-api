using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IPrescriptionRepository
  {
    Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync(string tenantId);
    Task<Prescription> GetPrescriptionByIdAsync(int id, string tenantId);
    Task AddPrescriptionAsync(Prescription prescription);
    Task UpdatePrescriptionAsync(Prescription prescription, string tenantId);
    Task DeletePrescriptionAsync(int id, string tenantId);
  }
}