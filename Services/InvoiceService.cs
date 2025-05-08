using ubuntu_health_api.Models;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class InvoiceService(IInvoiceRepository invoiceRepository) : IInvoiceService
  {
    private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;

    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync(string tenantId)
    {
      return await _invoiceRepository.GetAllInvoicesAsync(tenantId);
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id, string tenantId)
    {
      var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId);
      if (invoice == null || invoice.TenantId != tenantId)
      {
        throw new KeyNotFoundException("Invoice not found.");
      }
      return invoice;
    }
    public async Task AddInvoiceAsync(Invoice invoice, string tenantId)
    {
      invoice.TenantId = tenantId;
      await _invoiceRepository.AddInvoiceAsync(invoice, tenantId);
    }
    public async Task<bool> DeleteInvoiceAsync(int id, string tenantId)
    {
      var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId);
      if (invoice == null || invoice.TenantId != tenantId)
      {
        return false;
      }

      await _invoiceRepository.DeleteInvoiceAsync(id);
      return true;
    }
    public async Task<bool> UpdateInvoiceAsync(Invoice invoice, string tenantId)
    {
      var existingInvoice = await _invoiceRepository.GetInvoiceByIdAsync(invoice.InvoiceId, tenantId);
      if (existingInvoice == null || existingInvoice.TenantId != tenantId)
      {
        return false;
      }

      invoice.TenantId = tenantId;
      await _invoiceRepository.UpdateInvoiceAsync(invoice);
      return true;
    }
  }
}