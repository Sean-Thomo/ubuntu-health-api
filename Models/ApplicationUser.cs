using Microsoft.AspNetCore.Identity;

namespace ubuntu_health_api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int TenantId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; } // Admin, Receptionist, Nurse
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }

        public int? StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
        public string? LicenseNumber { get; internal set; }
        public string? Specialty { get; internal set; }
        public string? PracticeName { get; internal set; }
        public string? PracticePhone { get; internal set; }
    }
}