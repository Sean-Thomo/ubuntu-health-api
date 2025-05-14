using AutoMapper;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper) : IInvoiceService
  {
    private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync(string tenantId)
    {
      var invoices = await _invoiceRepository.GetAllInvoicesAsync(tenantId) ??
      throw new KeyNotFoundException("No Invoices found");
      return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
    }

    public async Task<InvoiceDto> GetInvoiceByIdAsync(int id, string tenantId)
    {
      var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId);
      if (invoice == null)
      {
        throw new KeyNotFoundException("Invoice not found.");
      }
      return _mapper.Map<InvoiceDto>(invoice);
    }
    public async Task AddInvoiceAsync(Invoice invoice, string tenantId)
    {
      invoice.TenantId = tenantId;
      await _invoiceRepository.AddInvoiceAsync(invoice);
    }
    public async Task<bool> DeleteInvoiceAsync(int id, string tenantId)
    {
      var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId);
      if (invoice == null)
      {
        return false;
      }

      await _invoiceRepository.DeleteInvoiceAsync(id);
      return true;
    }
    public async Task<bool> UpdateInvoiceAsync(Invoice invoice, string tenantId)
    {
      var existingInvoice = await _invoiceRepository.GetInvoiceByIdAsync(invoice.Id, tenantId);
      if (existingInvoice == null)
      {
        return false;
      }

      invoice.TenantId = tenantId;
      await _invoiceRepository.UpdateInvoiceAsync(invoice);
      return true;
    }
  }
}