using ubuntu_health_api.Data;
using ubuntu_health_api.Models;
using Microsoft.EntityFrameworkCore;
using ubuntu_health_api.Models.DTO;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Xml.Schema;

namespace ubuntu_health_api.Repositories
{
  public class ClinicalNoteRepository(AppDbContext dbContext) : IClinicalNoteRepository
  {
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<IEnumerable<ClinicalNote>> GetAllClinicalNotesAsync(string tenantId)
    {
      return await _dbContext.ClinicalNotes
        .Where(c => c.TenantId == tenantId)
        .ToListAsync();
    }

    public async Task<ClinicalNote> GetClinicalNoteByIdAsync(int id, string tenantId)
    {
      var clinicalNote = await _dbContext.ClinicalNotes
        .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId)
          ?? throw new KeyNotFoundException(
          $"ClinicalNote with ID {id} and Tenant ID {tenantId} was not found.");
      return clinicalNote;
    }

    public async Task AddClinicalNoteAsync(ClinicalNote clinicalNote)
    {
      await _dbContext.ClinicalNotes.AddAsync(clinicalNote);
      await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateClinicalNoteAsync(ClinicalNote clinicalNote, string tenantId)
    {
      var existingClinicalNote = await _dbContext.ClinicalNotes
      .FirstOrDefaultAsync(c => c.Id == clinicalNote.Id && c.TenantId == tenantId)
      ?? throw new KeyNotFoundException(
          $"ClinicalNote with ID {clinicalNote.Id} and Tenant ID {tenantId} was not found.");

      existingClinicalNote.Notes = clinicalNote.Notes;
      existingClinicalNote.DiagnosesCode = clinicalNote.DiagnosesCode;
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteClinicalNoteAsync(int id, string tenantId)
    {
      var clinicalNote = await _dbContext.ClinicalNotes
      .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

      if (clinicalNote != null)
      {
        _dbContext.ClinicalNotes.Remove(clinicalNote);
        await _dbContext.SaveChangesAsync();
      }
    }
  }
}