using ubuntu_health_api.Data;
using ubuntu_health_api.Models;
using Microsoft.EntityFrameworkCore;
using ubuntu_health_api.Models.DTO;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace ubuntu_health_api.Repositories
{
  public class ClinicalNoteRepository(AppDbContext dbContext, IMapper mapper) : IClinicalNoteRepository
  {
    private readonly AppDbContext _dbContext = dbContext;

    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ClinicalNoteDto>> GetAllClinicalNotesAsync(string tenantId)
    {
      return await _dbContext.ClinicalNotes
        .Where(c => c.TenantId == tenantId)
        .ProjectTo<ClinicalNoteDto>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public async Task<ClinicalNoteDto> GetClinicalNoteByIdAsync(int id, string tenantId)
    {
      var clinicalNote = await _dbContext.ClinicalNotes.FirstOrDefaultAsync(
        c => c.NoteId == id && c.TenantId == tenantId) ??
        throw new KeyNotFoundException(
          $"ClinicalNote with ID {id} and Tenant ID {tenantId} was not found.");
      return _mapper.Map<ClinicalNoteDto>(clinicalNote);
    }

    public async Task AddClinicalNoteAsync(ClinicalNote clinicalNote)
    {
      await _dbContext.ClinicalNotes.AddAsync(clinicalNote);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteClinicalNoteAsync(int id)
    {
      var clinicalNote = await _dbContext.ClinicalNotes.FindAsync(id);
      if (clinicalNote != null)
      {
        _dbContext.ClinicalNotes.Remove(clinicalNote);
        await _dbContext.SaveChangesAsync();
      }
    }

    public async Task UpdateClinicalNoteAsync(ClinicalNote clinicalNote)
    {
      _dbContext.ClinicalNotes.Update(clinicalNote);
      await _dbContext.SaveChangesAsync();
    }
  }
}