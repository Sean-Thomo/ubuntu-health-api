using ubuntu_health_api.Models;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class ClinicalNoteService(IClinicalNoteRepository clinicalNoteRepository) : IClinicalNoteService
  {
    private readonly IClinicalNoteRepository _clinicalNoteRepository = clinicalNoteRepository;

    public async Task<IEnumerable<ClinicalNote>> GetAllClinicalNotesAsync(string tenantId)
    {
      return await _clinicalNoteRepository.GetAllClinicalNotesAsync(tenantId);
    }

    public async Task<ClinicalNote> GetClinicalNoteByIdAsync(int id, string tenantId)
    {
      return await _clinicalNoteRepository.GetClinicalNoteByIdAsync(id, tenantId);
    }

    public async Task AddClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId)
    {
      await _clinicalNoteRepository.AddClinicalNoteAsync(clinicalNote);
    }

    public async Task<bool> DeleteClinicalNoteAsync(int id, string tenantId)
    {
      await _clinicalNoteRepository.DeleteClinicalNoteAsync(id, tenantId);
      return true;
    }

    public async Task<bool> UpdateClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId)
    {
      await _clinicalNoteRepository.UpdateClinicalNoteAsync(clinicalNote);
      return true;
    }
  }
}