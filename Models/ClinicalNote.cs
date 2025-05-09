namespace ubuntu_health_api.Models
{
  public class ClinicalNote
  {
    public required string NoteId { get; set; }
    public required string PatientId { get; set; }
    public required string DoctorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string Content { get; set; }
    public required string DiagnosesCode { get; set; } // ICD-10 code
  }
}