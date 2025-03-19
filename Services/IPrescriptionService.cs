using Backend.Models;

namespace Backend.Services
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        Task<Prescription> GetPrescriptionByIdAsync(int id);
        Task AddPrescriptionAsync(Prescription prescription);
        Task DeletePrescriptionAsync(int id);
        Task UpdatePrescriptionAsync(Prescription prescription);
    }
}