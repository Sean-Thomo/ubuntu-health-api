namespace ubuntu_health_api.Models {
    public class Tenant
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string OwnerEmail { get; set; }
        public required string SubscriptionPlan { get; set; }
        public required string CreatedAt { get; set; }
    }
}