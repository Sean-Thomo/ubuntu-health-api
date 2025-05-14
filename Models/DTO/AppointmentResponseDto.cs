namespace ubuntu_health_api.Models.DTO
{
  public class AppointmentResponseDto
  {
    public int Id { get; set; }
    public string? TenantId { get; set; }
    public int PatientId { get; set; }
    public string? PatientFirstName { get; set; }
    public string? PatientLastName { get; set; }
    public string? AppointmentDate { get; set; }
    public string? AppointmentTime { get; set; }
    public string? AppointmentType { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  }
}