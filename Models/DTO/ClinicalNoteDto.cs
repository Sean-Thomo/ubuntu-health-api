namespace ubuntu_health_api.Models.DTO
{
  public class ClinicalNoteDto
  {
    public required int NoteId { get; set; }
    public int PatientId { get; set; }
    public required string DoctorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string Notes { get; set; }
    public required string DiagnosesCode { get; set; } // ICD-10 code
  }
}