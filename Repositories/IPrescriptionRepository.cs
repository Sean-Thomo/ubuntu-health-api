using ubuntu_health_api.Models;

namespace ubuntu_health_api.Repositories
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        Task<Prescription> GetPrescriptionByIdAsync(int id);
        Task AddPrescriptionAsync(Prescription prescription);
        Task DeletePrescriptionAsync(int id);
        Task UpdatePrescriptionAsync(Prescription prescription);
    }
}