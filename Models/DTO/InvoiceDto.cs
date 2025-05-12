namespace ubuntu_health_api.Models.DTO
{
  public class InvoiceDto
  {
    public int InvoiceId { get; set; }
    public int PatientId { get; set; }
    public int AppointmentId { get; set; }
    public required string IssueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
  }
}