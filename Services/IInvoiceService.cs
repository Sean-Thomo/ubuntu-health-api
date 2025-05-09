using ubuntu_health_api.Models;

namespace ubuntu_health_api.Services
{
  public interface IInvoiceService
  {
    Task<IEnumerable<Invoice>> GetAllInvoicesAsync(string tenantId);
    Task<Invoice> GetInvoiceByIdAsync(int id, string tenantId);
    Task AddInvoiceAsync(Invoice invoice, string tenantId);
    Task<bool> DeleteInvoiceAsync(int id, string tenantId);
    Task<bool> UpdateInvoiceAsync(Invoice invoice, string tenantId);
  }
}