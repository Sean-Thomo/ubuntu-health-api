namespace ubuntu_health_api.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string TenantId { get; set; }
        public required string HireDate { get; set; }
        public required bool IsActive { get; set; }
        public required string UserName { get; set; }
    }
}