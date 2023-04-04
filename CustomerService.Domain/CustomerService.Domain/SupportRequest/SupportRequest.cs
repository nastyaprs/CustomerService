using CustomerService.Domain.Common.Models;
using CustomerService.Domain.SupportRequest.ValueObjects;

namespace CustomerService.Domain.SupportRequest
{
    public sealed class SupportRequest: AggregateRoot<SupportRequestId>
    {
        public string IssueDescription { get; set; } = null!;

        public string UrgencyLevel { get; set; } = null!;

        public DateTime DueDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Status { get; set; } = null!;

        public string StatusDetails { get; set; } = null!;

        public string IssueType { get; set; } = null!;

        public string IssueSubject { get; set; } = null!;

        private SupportRequest(SupportRequestId id, 
            string issueDescription,
            string urgencyLevel,
            DateTime dueDate,
            DateTime createdAt,
            DateTime updatedAt,
            string status,
            string statusDetails,
            string issueType,
            string issueSubject) : base(id)
        {
            IssueDescription = issueDescription;
            UrgencyLevel = urgencyLevel;
            DueDate = dueDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
            StatusDetails = statusDetails;
            IssueType = issueType;
            IssueSubject = issueSubject;
        }

        private readonly List<SupportRequestMessage.Entities.SupportRequestMessage> _supportRequestMessages = new();

        public ICollection<SupportRequestMessage.Entities.SupportRequestMessage> SupportRequestMessages => _supportRequestMessages.ToList();

        public static SupportRequest Create(string issueDescription,
            string urgencyLevel,
            DateTime dueDate,
            DateTime createdAt,
            DateTime updatedAt,
            string status,
            string statusDetails,
            string issueType,
            string issueSubject)
        {
            return new(SupportRequestId.CreateUnique(),
                issueDescription,
                urgencyLevel,
                dueDate,
                createdAt,
                updatedAt,
                status,
                statusDetails,
                issueType,
                issueSubject);
        }
    }
}
