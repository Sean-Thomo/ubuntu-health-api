using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Services
{
  public interface IInvoiceService
  {
    Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync(string tenantId);
    Task<InvoiceDto> GetInvoiceByIdAsync(int id, string tenantId);
    Task AddInvoiceAsync(Invoice invoice, string tenantId);
    Task<bool> DeleteInvoiceAsync(int id, string tenantId);
    Task<bool> UpdateInvoiceAsync(Invoice invoice, string tenantId);
  }
}