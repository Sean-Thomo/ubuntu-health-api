namespace ubuntu_health_api.Models.DTO
{
  public class InvoiceUpdateDto
  {
    public int Id { get; set; }
    public required string TenantId { get; set; }
    public int PatientId { get; set; }
    public int AppointmentId { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
  }
}