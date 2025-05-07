namespace ubuntu_health_api.Models
{
    public class Staff : Person
    {
        public string? Department { get; set; }
        public required string Role { get; set; }
        public string? SupervisorId { get; set; }
    }
}
