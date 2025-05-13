using AutoMapper;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class ClinicalNoteService(IClinicalNoteRepository clinicalNoteRepository, IMapper mapper) : IClinicalNoteService
  {
    private readonly IClinicalNoteRepository _clinicalNoteRepository = clinicalNoteRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ClinicalNoteDto>> GetAllClinicalNotesAsync(string tenantId)
    {

      var clinicalNote = await _clinicalNoteRepository.GetAllClinicalNotesAsync(tenantId) ?? throw new KeyNotFoundException("No Clinical Notes Found");
      return _mapper.Map<IEnumerable<ClinicalNoteDto>>(clinicalNote);
    }

    public async Task<ClinicalNoteDto> GetClinicalNoteByIdAsync(int id, string tenantId)
    {
      var clinicalNote = await _clinicalNoteRepository.GetClinicalNoteByIdAsync(id, tenantId) ??
      throw new KeyNotFoundException("Clinical note not found.");
      return _mapper.Map<ClinicalNoteDto>(clinicalNote);
    }

    public async Task AddClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId)
    {
      clinicalNote.TenantId = tenantId;
      await _clinicalNoteRepository.AddClinicalNoteAsync(clinicalNote);
    }

    public async Task<bool> DeleteClinicalNoteAsync(int id, string tenantId)
    {
      var clinicalNote = await _clinicalNoteRepository.GetClinicalNoteByIdAsync(id, tenantId);
      if (clinicalNote == null)
      {
        return false;
      }
      await _clinicalNoteRepository.DeleteClinicalNoteAsync(id);
      return true;
    }

    public async Task<bool> UpdateClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId)
    {
      var existingClinicalNote = await _clinicalNoteRepository.GetClinicalNoteByIdAsync(clinicalNote.NoteId, tenantId);
      if (existingClinicalNote == null)
      {
        return false;
      }

      clinicalNote.TenantId = tenantId;
      await _clinicalNoteRepository.UpdateClinicalNoteAsync(clinicalNote);
      return true;
    }
  }
}