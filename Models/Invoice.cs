namespace ubuntu_health_api.Models
{
  public class Invoice
  {
    public int Id { get; set; }
    public required string TenantId { get; set; }
    public int PatientId { get; set; }
    public int AppointmentId { get; set; }
    public required DateTime IssueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public Patient? Patient { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  }
}