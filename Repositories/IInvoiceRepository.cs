using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IInvoiceRepository
  {
    Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync(string tenantId);
    Task<InvoiceDto> GetInvoiceByIdAsync(int id, string tenantId);
    Task AddInvoiceAsync(Invoice invoice);
    Task DeleteInvoiceAsync(int id);
    Task UpdateInvoiceAsync(Invoice invoice);
  }
}