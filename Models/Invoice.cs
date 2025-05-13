namespace ubuntu_health_api.Models
{
  public class Invoice
  {
    public int Id { get; set; }
    public required string TenantId { get; set; }
    public int PatientId { get; set; }
    public int AppointmentId { get; set; }
    public required string IssueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public required string CreatedAt { get; set; }
    public required string UpdatedAt { get; set; }
  }
}