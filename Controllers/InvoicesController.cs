using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Helpers;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;

namespace ubuntu_health_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InvoicesController(IInvoiceService invoiceService, IHttpContextAccessor httpContextAccessor) : ControllerBase
  {
    private readonly IInvoiceService _invoiceService = invoiceService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    [HttpGet]
    [Authorize(Roles = "admin, receptionist")]
    public async Task<IActionResult> GetAllInvoices()
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var invoices = await _invoiceService.GetAllInvoicesAsync(tenantId);
      return Ok(invoices);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin, receptionist")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var invoice = await _invoiceService.GetInvoiceByIdAsync(id, tenantId);
      if (invoice == null) return NotFound();

      return Ok(invoice);
    }

    [HttpPost]
    [Authorize(Roles = "admin, receptionist")]
    public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      if (invoice == null)
      {
        return BadRequest("Invoice cannot be null");
      }

      await _invoiceService.AddInvoiceAsync(invoice, tenantId);
      return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.InvoiceId }, invoice);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin, receptionist")]
    public async Task<IActionResult> UpdateInvoice(int id, [FromBody] Invoice invoice)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var existingInvoice = await _invoiceService.GetInvoiceByIdAsync(id, tenantId);
      if (existingInvoice == null) return NotFound();

      await _invoiceService.UpdateInvoiceAsync(invoice, tenantId);
      return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin, receptionist")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var invoice = await _invoiceService.GetInvoiceByIdAsync(id, tenantId);
      if (invoice == null) return NotFound();

      await _invoiceService.DeleteInvoiceAsync(id, tenantId);
      return NoContent();
    }
  }
}

