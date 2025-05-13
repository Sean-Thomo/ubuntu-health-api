namespace ubuntu_health_api.Models
{
  public class ClinicalNote
  {
    public int Id { get; set; }
    public required string TenantId { get; set; }
    public int PatientId { get; set; }
    public required string DoctorId { get; set; }
    public string? Notes { get; set; }
    public required string DiagnosesCode { get; set; } // ICD-10 code
    public Patient? Patient { get; set; }
    public required string CreatedAt { get; set; }
    public required string UpdatedAt { get; set; }
  }
}