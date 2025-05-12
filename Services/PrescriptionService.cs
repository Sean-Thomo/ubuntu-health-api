using AutoMapper;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper) : IPrescriptionService
  {
    private readonly IPrescriptionRepository _prescriptionRepository = prescriptionRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync(string tenantId)
    {
      var prescriptions = await _prescriptionRepository.GetAllPrescriptionsAsync(tenantId) ??
      throw new KeyNotFoundException("No Prescriptions Found");
      return _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
    }

    public async Task<PrescriptionDto> GetPrescriptionByIdAsync(int id, string tenantId)
    {
      var prescription = await _prescriptionRepository.GetPrescriptionByIdAsync(id, tenantId) ??
      throw new KeyNotFoundException("Prescription not found");
      return _mapper.Map<PrescriptionDto>(prescription);
    }

    public async Task AddPrescriptionAsync(Prescription prescription, string tenantId)
    {
      prescription.TenantId = tenantId;
      await _prescriptionRepository.AddPrescriptionAsync(prescription);
    }

    public async Task<bool> DeletePrescriptionAsync(int id, string tenantId)
    {
      var prescription = await _prescriptionRepository.GetPrescriptionByIdAsync(id, tenantId);
      if (prescription == null)
      {
        return false;
      }

      await _prescriptionRepository.DeletePrescriptionAsync(id);
      return true;
    }

    public async Task<bool> UpdatePrescriptionAsync(Prescription prescription, string tenantId)
    {
      var existingPrescription = await _prescriptionRepository.GetPrescriptionByIdAsync(prescription.PrescriptionId, tenantId);
      if (existingPrescription == null)
      {
        return false;
      }

      prescription.TenantId = tenantId;
      await _prescriptionRepository.UpdatePrescriptionAsync(prescription);
      return true;
    }
  }
}