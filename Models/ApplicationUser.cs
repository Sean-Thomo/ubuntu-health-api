using Microsoft.AspNetCore.Identity;

namespace ubuntu_health_api.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string? TenantId { get; set; }
    public required string SubscriptionPlan { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  }
}