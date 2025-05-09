using ubuntu_health_api.Models;

namespace ubuntu_health_api.Services
{
  public interface IClinicalNoteService
  {
    Task<IEnumerable<ClinicalNote>> GetAllClinicalNotesAsync(string tenantId);
    Task<ClinicalNote> GetClinicalNoteByIdAsync(int id, string tenantId);
    Task AddClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId);
    Task<bool> DeleteClinicalNoteAsync(int id, string tenantId);
    Task<bool> UpdateClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId);
  }
}