namespace ubuntu_health_api.Models.DTO
{
  public class AppointmentUpdateDto
  {
    public string? AppointmentDate { get; set; }
    public string? AppointmentTime { get; set; }
    public string? AppointmentType { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
  }
}