namespace Backend.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedication { get; set; }
        public string EmergencyContactFirstName { get; set; }
        public string EmergencyContactLastName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string MedicalAidName { get; set; }
        public string MembershipNumber { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; } 
    }
}