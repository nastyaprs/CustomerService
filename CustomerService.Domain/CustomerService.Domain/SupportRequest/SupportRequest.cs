using CustomerService.Domain.Common.Models;
using CustomerService.Domain.SupportRequest.ValueObjects;
using CustomerService.Domain.User.ValueObjects;

namespace CustomerService.Domain.SupportRequest
{
    public sealed class SupportRequest: AggregateRoot<SupportRequestId>
    {
        public UserId CustomerId { get; set; }

        public string IssueSubject { get; set; } = null!;

        public string IssueType { get; set; } = null!;

        public string IssueDescription { get; set; } = null!;

        public string UrgencyLevel { get; set; } = null!;

        public DateTime DueDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Status { get; set; } = null!;

        public string? StatusDetails { get; set; } = null!;

        private SupportRequest(SupportRequestId id,
            UserId customerId,
            string issueSubject,
            string issueType,
            string issueDescription,
            string urgencyLevel) : base(id)
        {
            CustomerId = customerId;
            IssueSubject = issueSubject;
            IssueType = issueType;
            IssueDescription = issueDescription;
            UrgencyLevel = urgencyLevel;
        }

        private readonly List<SupportRequestMessage.Entities.SupportRequestMessage> _supportRequestMessages = new();

        public ICollection<SupportRequestMessage.Entities.SupportRequestMessage> SupportRequestMessages => _supportRequestMessages.ToList();

        public static SupportRequest Create(UserId customerId,
            string issueSubject,
            string issueType,
            string issueDescription,
            string urgencyLevel)
        {
            return new(SupportRequestId.CreateUnique(),
                customerId,
                issueSubject,
                issueType,
                issueDescription,
                urgencyLevel);
        }
    }
}
