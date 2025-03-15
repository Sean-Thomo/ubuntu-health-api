namespace Backend.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TenantId { get; set; }
        public required Patient Patient { get; set; }
        public string IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } //Paid, Pending, Overdue
        public string Notes { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}