namespace ubuntu_health_api.Models
{
        public class PrescriptionMedication
    {
        public int Id { get; set; }
        
        public int PrescriptionId { get; set; }
        
        public Prescription? Prescription { get; set; }
        
        public string Name { get; set; }
        
        public string Dosage { get; set; }
        
        public string? Instructions { get; set; }
    }
}