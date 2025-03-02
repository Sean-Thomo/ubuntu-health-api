namespace Backend.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId  { get; set; }
        public string InvoiceDate { get; set; }
        public string TotalAmount { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}