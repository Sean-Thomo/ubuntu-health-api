  using ubuntu_health_api.Models;
  
namespace ubuntu_health_api.Repositories
{
    public interface IInvoiceRepository
    {
      Task<IEnumerable<Invoice>> GetAllInvoicesAsync(string tenantId);
      Task<Invoice> GetInvoiceByIdAsync(int id, string InvoiceId);
      Task AddInvoiceAsync(Invoice invoice, string tenantId);
      Task DeleteInvoiceAsync(int id);
      Task UpdateInvoiceAsync(Invoice invoice);
    }
}