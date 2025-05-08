using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Helpers;
using ubuntu_health_api.Models;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InvoiceController(IInvoiceRepository invoiceRepository, IPatientRepository patientRepository, IHttpContextAccessor httpContextAccessor) : ControllerBase
  {
    private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;
    private readonly IPatientRepository _patientRepository = patientRepository;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    [HttpGet]
    [Authorize(Roles = "Admin, Receptionist")]
    public async Task<IActionResult> GetAllInvoices()
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var invoices = await _invoiceRepository.GetAllInvoicesAsync(tenantId);
      return Ok(invoices);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, Receptionist")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId);
      if (invoice == null)
      {
        return NotFound();
      }
      return Ok(invoice);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Receptionist")]
    public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      if (invoice == null)
      {
        return BadRequest("Invoice cannot be null");
      }

      var patient = await _patientRepository.GetPatientByIdAsync(invoice.PatientId, invoice.TenantId);
      if (patient == null)
      {
        return NotFound($"Patient with ID {invoice.PatientId} not found.");
      }

      await _invoiceRepository.AddInvoiceAsync(invoice, tenantId);
      return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.InvoiceId }, invoice);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Receptionist")]
    public async Task<IActionResult> UpdateInvoice(int id, [FromBody] Invoice invoice)
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      if (id != invoice.InvoiceId)
      {
        return BadRequest("Invoice ID mismatch");
      }

      var existingInvoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId);
      if (existingInvoice == null)
      {
        return NotFound($"Invoice with ID {id} not found.");
      }

      await _invoiceRepository.UpdateInvoiceAsync(invoice);
      return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Receptionist")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id, tenantId);
      if (invoice == null)
      {
        return NotFound($"Invoice with ID {id} not found.");
      }

      await _invoiceRepository.DeleteInvoiceAsync(id);
      return NoContent();
    }
  }
}

