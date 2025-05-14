namespace ubuntu_health_api.Models.DTO
{
  public class PrescriptionUpdateDto
  {
    public required string Dosage { get; set; }
    public string? Frequency { get; set; }
    public int Refills { get; set; } = 0;
    public string? Status { get; set; }
    public string? Instructions { get; set; }
  }
}