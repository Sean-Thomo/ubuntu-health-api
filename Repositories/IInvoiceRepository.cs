using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IInvoiceRepository
  {
    Task<IEnumerable<Invoice>> GetAllInvoicesAsync(string tenantId);
    Task<Invoice> GetInvoiceByIdAsync(int id, string tenantId);
    Task AddInvoiceAsync(Invoice invoice);
    Task UpdateInvoiceAsync(Invoice invoice, string tenantId);
    Task DeleteInvoiceAsync(int id, string tenantId);
  }
}