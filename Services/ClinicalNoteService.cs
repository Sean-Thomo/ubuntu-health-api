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
      var clinicalNote = await _clinicalNoteRepository.GetClinicalNoteByIdAsync(id, tenantId);
      if (clinicalNote == null || clinicalNote.TenantId != tenantId)
      {
        throw new KeyNotFoundException("Clinical note not found.");
      }
      return clinicalNote;
    }

    public async Task AddClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId)
    {
      clinicalNote.TenantId = tenantId;
      await _clinicalNoteRepository.AddClinicalNoteAsync(clinicalNote);
    }

    public async Task<bool> DeleteClinicalNoteAsync(int id, string tenantId)
    {
      var clinicalNote = await _clinicalNoteRepository.GetClinicalNoteByIdAsync(id, tenantId);
      if (clinicalNote == null || clinicalNote.TenantId != tenantId)
      {
        return false;
      }
      await _clinicalNoteRepository.DeleteClinicalNoteAsync(id);
      return true;
    }

    public async Task<bool> UpdateClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId)
    {
      var existingClinicalNote = await _clinicalNoteRepository.GetClinicalNoteByIdAsync(clinicalNote.NoteId, tenantId);
      if (existingClinicalNote == null || existingClinicalNote.TenantId != tenantId)
      {
        return false;
      }
      clinicalNote.TenantId = tenantId;
      await _clinicalNoteRepository.UpdateClinicalNoteAsync(clinicalNote);
      return true;
    }
  }
}