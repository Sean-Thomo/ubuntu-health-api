using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
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