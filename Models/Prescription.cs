namespace ubuntu_health_api.Models
{
  public class Prescription
  {
    public int Id { get; set; }
    public required string TenantId { get; set; }
    public int PatientId { get; set; }
    public int PractitionerId { get; set; }
    public required string Dosage { get; set; }
    public required string IssueDate { get; set; }
    public required string? EndDate { get; set; }
    public string? Frequency { get; set; }
    public int Refills { get; set; } = 0;
    public string? Status { get; set; }
    public List<PrescriptionMedication> Medications { get; set; } = [];
    public string? Instructions { get; set; }
    public Patient? Patient { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  }
}