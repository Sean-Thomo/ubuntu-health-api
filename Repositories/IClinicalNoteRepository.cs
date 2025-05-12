using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IClinicalNoteRepository
  {
    Task<IEnumerable<ClinicalNoteDto>> GetAllClinicalNotesAsync(string tenantId);
    Task<ClinicalNoteDto> GetClinicalNoteByIdAsync(int id, string tenantId);
    Task AddClinicalNoteAsync(ClinicalNote clinicalNote);
    Task DeleteClinicalNoteAsync(int id);
    Task UpdateClinicalNoteAsync(ClinicalNote clinicalNote);
  }
}