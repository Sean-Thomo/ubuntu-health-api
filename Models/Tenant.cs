namespace Backend.Models {
    public class Tenant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OwnerEmail { get; set; }
        public string SubscriptionPlan { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}