namespace ubuntu_health_api.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int PatientId { get; set; }
        public required string TenantId { get; set; }
        public required Patient Patient { get; set; }
        public string IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } //Paid, Pending, Overdue
        public string Notes { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}