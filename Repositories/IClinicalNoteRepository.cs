using ubuntu_health_api.Models;

namespace ubuntu_health_api.Repositories
{
  public interface IClinicalNoteRepository
  {
    Task<IEnumerable<ClinicalNote>> GetAllClinicalNotesAsync(string tenantId);
    Task<ClinicalNote> GetClinicalNoteByIdAsync(int id, string tenantId);
    Task AddClinicalNoteAsync(ClinicalNote clinicalNote);
    Task DeleteClinicalNoteAsync(int id, string tenantId);
    Task UpdateClinicalNoteAsync(ClinicalNote clinicalNote);
  }
}