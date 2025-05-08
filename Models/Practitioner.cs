namespace ubuntu_health_api.Models
{
  public class Practitioner : Person
  {
    public required string LicenseNumber { get; set; }
    public string? NPI { get; set; }
    public required string Specialty { get; set; }
    public required string LicenseExpiration { get; set; }
    public string? DEANumber { get; set; }
    public required bool CanPrescribe { get; set; }
  }
}