namespace Backend.Models
{
    public class Prescription 
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TenantId { get; set; }
        public Patient? Patient { get; set; }
        public int PractitionerId { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Instructions { get; set; }
        public string IssueDate { get; set; }
        public string ExpiryDate { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}