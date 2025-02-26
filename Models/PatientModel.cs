namespace Backend.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Allergies { get; set; }
        public string ChronicMedication { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string MedicalAid { get; set; }
        public string MedicalAidNumber { get; set; }
        public string MedicalAidPlan { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}