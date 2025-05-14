using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Services
{
  public interface IInvoiceService
  {
    Task<IEnumerable<InvoiceResponseDto>> GetAllInvoicesAsync(string tenantId);
    Task<InvoiceResponseDto> GetInvoiceByIdAsync(int id, string tenantId);
    Task<InvoiceResponseDto> AddInvoiceAsync(InvoiceCreateDto createDto, string tenantId);
    Task<InvoiceResponseDto> UpdateInvoiceAsync(int id, InvoiceUpdateDto updateDto, string tenantId);
    Task<bool> DeleteInvoiceAsync(int id, string tenantId);
  }
}