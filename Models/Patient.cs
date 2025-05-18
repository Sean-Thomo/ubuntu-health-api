
namespace ubuntu_health_api.Models
{
  public class Patient
  {
    public int Id { get; set; }
    public required string TenantId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? IdNumber { get; set; }
    public required string Sex { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Street { get; set; }
    public string? StreetTwo { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? PostalCode { get; set; }
    public string? Allergies { get; set; }
    public string? CurrentMedication { get; set; }
    public string? EmergencyContactFirstName { get; set; }
    public string? EmergencyContactLastName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public string? EmergencyContactRelationship { get; set; }
    public string? MedicalAidName { get; set; }
    public string? MembershipNumber { get; set; }
    public List<Appointment> Appointments { get; set; } = [];
    public List<ClinicalNote> ClinicalNotes { get; set; } = [];
    public List<Prescription> Prescriptions { get; set; } = [];
    public List<Invoice> Invoices { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}