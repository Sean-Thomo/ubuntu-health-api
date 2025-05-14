namespace ubuntu_health_api.Models.DTO
{
  public class InvoiceCreateDto
  {
    public int PatientId { get; set; }
    public int AppointmentId { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
  }
}