namespace ubuntu_health_api.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Role { get; set; } // Admin, Receptionist, Nurse,
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
