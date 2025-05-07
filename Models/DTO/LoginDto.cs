namespace ubuntu_health_api.Models.DTO
{
    public class LoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}