namespace ubuntu_health_api.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public required string TenantId { get; set; }
    public int PatientId { get; set; }
    public required string PatientFirstName { get; set; }
    public required string PatientLastName { get; set; }
    public required string AppointmentDate { get; set; }
    public string? AppointmentTime { get; set; }
    public string? AppointmentType { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public string? DiagnosisCode { get; set; }
    public required string CreatedAt { get; set; }
    public required string UpdatedAt { get; set; }
  }
}