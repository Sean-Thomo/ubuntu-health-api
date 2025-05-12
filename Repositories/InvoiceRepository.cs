using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ubuntu_health_api.Data;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public class InvoiceRepository(AppDbContext dbContext, IMapper mapper) : IInvoiceRepository
  {
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task AddInvoiceAsync(Invoice invoice)
    {
      await _dbContext.Invoices.AddAsync(invoice);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteInvoiceAsync(int id)
    {
      var invoice = await _dbContext.Invoices.FindAsync(id);
      if (invoice != null)
      {
        _dbContext.Invoices.Remove(invoice);
        await _dbContext.SaveChangesAsync();
      }
    }

    public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync(string tenantId)
    {
      return await _dbContext.Invoices
      .Where(i => i.TenantId == tenantId)
      .ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider)
      .ToListAsync();
    }

    public async Task<InvoiceDto> GetInvoiceByIdAsync(int id, string tenantId)
    {
      var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(
        i => i.AppointmentId == id && i.TenantId == tenantId) ??
        throw new KeyNotFoundException(
          $"Appointment with ID {id} was not found."
        );

      return _mapper.Map<InvoiceDto>(invoice);

    }

    public async Task UpdateInvoiceAsync(Invoice invoice)
    {
      _dbContext.Invoices.Update(invoice);
      await _dbContext.SaveChangesAsync();
    }
  }
}