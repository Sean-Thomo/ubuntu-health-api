using ubuntu_health_api.Models;
using ubuntu_health_api.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ubuntu_health_api.Models.DTO;
using AutoMapper.QueryableExtensions;

namespace ubuntu_health_api.Repositories
{
  public class PrescriptionRepository(AppDbContext dbContext, IMapper mapper) : IPrescriptionRepository
  {
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;


    public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync(string tenantId)
    {
      return await _dbContext.Prescriptions
      .Where(p => p.TenantId == tenantId)
      .ProjectTo<PrescriptionDto>(_mapper.ConfigurationProvider)
      .ToListAsync();
    }

    public async Task<PrescriptionDto> GetPrescriptionByIdAsync(int id, string tenantId)
    {
      var prescription = await _dbContext.Prescriptions.FirstOrDefaultAsync(
        p => p.PatientId == id && p.TenantId == tenantId
      ) ?? throw new KeyNotFoundException(
        $"Prescription with ID {id} was not found."
      );

      return _mapper.Map<PrescriptionDto>(prescription);
    }

    public async Task AddPrescriptionAsync(Prescription prescription)
    {
      await _dbContext.Prescriptions.AddAsync(prescription);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePrescriptionAsync(int id)
    {
      var prescription = await _dbContext.Prescriptions.FindAsync(id);
      if (prescription != null)
      {
        _dbContext.Prescriptions.Remove(prescription);
        await _dbContext.SaveChangesAsync();
      }
    }

    public async Task UpdatePrescriptionAsync(Prescription prescription)
    {
      _dbContext.Prescriptions.Update(prescription);
      await _dbContext.SaveChangesAsync();
    }
  }
}