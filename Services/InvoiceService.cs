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

    public async Task<IEnumerable<InvoiceResponseDto>> GetAllInvoicesAsync(string tenantId)
    {
      var invoices = await _invoiceRepository.GetAllInvoicesAsync(tenantId) ??
      throw new KeyNotFoundException("No Invoices found");
      return _mapper.Map<IEnumerable<InvoiceResponseDto>>(invoices);
    }

    public async Task<InvoiceResponseDto> GetInvoiceByIdAsync(int id, string tenantId)
    {
      var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId)
        ?? throw new KeyNotFoundException("Invoice not found.");
      return _mapper.Map<InvoiceResponseDto>(invoice);
    }

    public async Task<InvoiceResponseDto> AddInvoiceAsync(InvoiceCreateDto createDto, string tenantId)
    {
      var invoice = _mapper.Map<Invoice>(createDto);
      invoice.TenantId = tenantId;
      invoice.CreatedAt = DateTime.UtcNow;
      invoice.CreatedAt = DateTime.UtcNow;

      await _invoiceRepository.AddInvoiceAsync(invoice);

      return _mapper.Map<InvoiceResponseDto>(invoice);
    }

    public async Task<InvoiceResponseDto> UpdateInvoiceAsync(int id, InvoiceUpdateDto updateDto, string tenantId)
    {
      var existingInvoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId)
        ?? throw new KeyNotFoundException("Invoice not found");

      _mapper.Map(updateDto, existingInvoice);
      existingInvoice.UpdatedAt = DateTime.UtcNow;

      await _invoiceRepository.UpdateInvoiceAsync(existingInvoice, tenantId);
      return _mapper.Map<InvoiceResponseDto>(existingInvoice);
    }

    public async Task<bool> DeleteInvoiceAsync(int id, string tenantId)
    {
      try
      {
        await _invoiceRepository.DeleteInvoiceAsync(id, tenantId);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}