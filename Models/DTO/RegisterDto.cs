namespace ubuntu_health_api.Models.DTO
{
  public class RegisterDto
  {
    public string? TenantId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string SubscriptionPlan { get; set; }
    public required string Password { get; set; }
    public string? Role { get; set; }
    public string? Specialty { get; set; }
    public string? PracticeName { get; set; }
    public string? PracticePhone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  }
}