using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class PrescriptionService(IPrescriptionRepository prescriptionRepository) : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository = prescriptionRepository;

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _prescriptionRepository.GetAllPrescriptionsAsync();
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _prescriptionRepository.GetPrescriptionByIdAsync(id);
        }

        public async Task AddPrescriptionAsync(Prescription prescription)
        {
            await _prescriptionRepository.AddPrescriptionAsync(prescription);
        }

        public async Task DeletePrescriptionAsync(int id)
        {
            await _prescriptionRepository.DeletePrescriptionAsync(id);
        }

        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            await _prescriptionRepository.UpdatePrescriptionAsync(prescription);
        }
    }
}