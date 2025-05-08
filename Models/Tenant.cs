using System.ComponentModel.DataAnnotations;

namespace ubuntu_health_api.Models
{
  public class Tenant
  {
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required]
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string OwnerEmail { get; set; }
    public required string SubscriptionPlan { get; set; }
    public required string CreatedAt { get; set; }
  }
}