namespace Backend.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientFirstName { get; set; }
        public int PatientLastName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentType  { get; set; }
        public string Status { get; set; }
        public string Notes {get; set;}
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}