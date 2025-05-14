namespace ubuntu_health_api.Models.DTO
{
  public class ClinicalNoteCreateDto
  {
    public required int PatientId { get; set; }
    public required string DoctorId { get; set; }
    public string? Notes { get; set; }
    public required string DiagnosesCode { get; set; } // ICD-10 code
    public Patient? Patient { get; set; }
  }
}