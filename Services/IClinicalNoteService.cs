using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Services
{
  public interface IClinicalNoteService
  {
    Task<IEnumerable<ClinicalNoteDto>> GetAllClinicalNotesAsync(string tenantId);
    Task<ClinicalNoteDto> GetClinicalNoteByIdAsync(int id, string tenantId);
    Task AddClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId);
    Task<bool> DeleteClinicalNoteAsync(int id, string tenantId);
    Task<bool> UpdateClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId);
  }
}