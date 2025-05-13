namespace ubuntu_health_api.Models
{
  public class ClinicalNote
  {
    public int NoteId { get; set; }
    public int PatientId { get; set; }
    public required string TenantId { get; set; }
    public required string DoctorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string Notes { get; set; }
    public required string DiagnosesCode { get; set; } // ICD-10 code
  }
}