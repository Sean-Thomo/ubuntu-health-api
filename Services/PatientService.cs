using ubuntu_health_api.Models;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(string tenantId)
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id, string tenantId)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }

        public async Task AddPatientAsync(Patient patient, string tenantId)
        {
            await _patientRepository.AddPatientAsync(patient);
        }

        public async Task DeletePatientAsync(int id, string tenantId)
        {
            await _patientRepository.DeletePatientAsync(id);
        }

        public async Task UpdatePatientAsync(Patient patient, string tenantId)
        {
            await _patientRepository.UpdatePatientAsync(patient);
        }
    }
}