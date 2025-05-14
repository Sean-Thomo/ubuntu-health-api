namespace ubuntu_health_api.Models.DTO
{
  public class ClinicalNoteUpdateDto
  {
    public string? Notes { get; set; }
    public required string DiagnosesCode { get; set; }
  }
}