namespace ubuntu_health_api.Models
{
    public class Practitioner
    {
        public int Id { get; set; }
        public required string TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicenceNumber { get; set; }
        public string Specialization { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}