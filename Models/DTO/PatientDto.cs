using System.ComponentModel.DataAnnotations;

namespace ubuntu_health_api.Models.DTO
{
  public class PatientDto
  {
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "ID number is required")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be exactly 13 characters")]
    [RegularExpression(@"^\d{13}$", ErrorMessage = "ID number must contain only digits")]
    public string IdNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Sex is required")]
    [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Sex must be Male, Female, or Other")]
    public string Sex { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters")]
    public string Phone { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Street address cannot exceed 100 characters")]
    public string? Street { get; set; }

    [StringLength(100, ErrorMessage = "Street address line 2 cannot exceed 100 characters")]
    public string? StreetTwo { get; set; }

    [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
    public string? City { get; set; }

    [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters")]
    public string? Province { get; set; }

    [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters")]
    public string? PostalCode { get; set; }

    [StringLength(500, ErrorMessage = "Allergies cannot exceed 500 characters")]
    public string? Allergies { get; set; }

    [StringLength(500, ErrorMessage = "Current medication cannot exceed 500 characters")]
    public string? CurrentMedication { get; set; }

    [StringLength(100, ErrorMessage = "Medical aid name cannot exceed 100 characters")]
    public string? MedicalAidName { get; set; }

    [StringLength(50, ErrorMessage = "Membership number cannot exceed 50 characters")]
    public string? MembershipNumber { get; set; }

    [StringLength(50, ErrorMessage = "Emergency contact first name cannot exceed 50 characters")]
    public string? EmergencyContactFirstName { get; set; }

    [StringLength(50, ErrorMessage = "Emergency contact last name cannot exceed 50 characters")]
    public string? EmergencyContactLastName { get; set; }

    [Phone(ErrorMessage = "Invalid emergency contact phone number format")]
    [StringLength(15, ErrorMessage = "Emergency contact phone cannot exceed 15 characters")]
    public string? EmergencyContactPhone { get; set; }

    [StringLength(50, ErrorMessage = "Emergency contact relationship cannot exceed 50 characters")]
    public string? EmergencyContactRelationship { get; set; }
  }
}