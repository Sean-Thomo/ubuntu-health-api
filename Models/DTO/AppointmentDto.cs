namespace ubuntu_health_api.Models.DTO
{
  public class AppointmentDto
  {
    public int AppointmentId { get; set; }
    public required string PatientFirstName { get; set; }
    public required string PatientLastName { get; set; }
    public required string AppointmentDate { get; set; }
    public string? AppointmentTime { get; set; }
    public string? AppointmentType { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }

  }
}