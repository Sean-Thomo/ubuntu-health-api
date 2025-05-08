using Microsoft.AspNetCore.Identity;

namespace ubuntu_health_api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string TenantId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; } // Admin, Receptionist, Nurse
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}