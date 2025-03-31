namespace ubuntu_health_api.Models.DTO
{
public class AuthResponseDto
{
    public bool IsSuccess { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public string? Message { get; set; }
    public string? Email { get; set; }
    public IEnumerable<string>? Roles { get; set; }
    public IEnumerable<string>? Errors { get; set; } // Add this
}
}