namespace ubuntu_health_api.Models.DTO
{
  public class PatientDto
  {
    public int PatientId { get; set; }
    public required string TenantId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? IdNumber { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? MedicalAidName { get; set; }
    public string? MembershipNumber { get; set; }
    public string? EmergencyContactFirstName { get; set; }
    public string? EmergencyContactPhone { get; set; }
  }
}