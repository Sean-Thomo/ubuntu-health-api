namespace ubuntu_health_api.Models.DTO
{
  public class PrescriptionDto
  {
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int PractitionerId { get; set; }
    public required string Dosage { get; set; }
    public required string IssueDate { get; set; }
    public required string? EndDate { get; set; }
    public string? Frequency { get; set; }
    public int Refills { get; set; } = 0;
    public string? Status { get; set; }
    public string? Instructions { get; set; }
  }
}