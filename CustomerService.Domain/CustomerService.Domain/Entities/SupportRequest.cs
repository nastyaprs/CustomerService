using CustomerService.Domain.Common.Models;


namespace CustomerService.Domain.Entities
{
    public sealed class SupportRequest : BaseEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public User Customer { get; set; } = null!;
        public string IssueDescription { get; set; } = null!;
        public string UrgencyLevel { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = null!;
        public string StatusDetails { get; set; } = String.Empty;
        public string IssueType { get; set; } = String.Empty;
        public string IssueSubject { get; set; } = null!;
        public ICollection<SupportRequestMessage> SupportRequestMessages { get; set; }
    }
}
