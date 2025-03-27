namespace ubuntu_health_api.Models
{
    public class Prescription 
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int PractitionerId { get; set; }
        public string Status { get; set; };
        public DateTime IssueDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Frequency { get; set; }
        public int Refills { get; set; } = 0;
        public string? Instructions { get; set; }
        public int TenantId { get; set; }
        public List<PrescriptionMedication> Medications { get; set; } = new List<PrescriptionMedication>();
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}