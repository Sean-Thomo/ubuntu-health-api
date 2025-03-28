namespace ubuntu_health_api.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int TenantId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentType { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}