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
        public required string CreatedAt { get; set; }
        public required string UpdatedAt { get; set; }

        public int? StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}