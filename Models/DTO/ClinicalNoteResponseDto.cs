namespace ubuntu_health_api.Models.DTO
{
  public class ClinicalNoteResponseDto
  {
    public int Id { get; set; }
    public string? TenantId { get; set; }
    public int PatientId { get; set; }
    public required string DoctorId { get; set; }
    public required string DiagnosesCode { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}