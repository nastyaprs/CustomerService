using CustomerService.Domain.Common.Models;
using CustomerService.Domain.SupportRequest.ValueObjects;
using CustomerService.Domain.SupportRequestMessage.ValueObjects;

namespace CustomerService.Domain.SupportRequestMessage.Entities
{
    public sealed class SupportRequestMessage: Entity<SupportRequestMessageId>
    {
        public SupportRequestId SupportRequestId { get; set; }

        public string Content { get; set;  } = null!;

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        private SupportRequestMessage(SupportRequestMessageId id, 
            SupportRequestId supportRequestId, 
            string content,
            DateTime createdAt,
            string createdBy) : base(id)
        {
            SupportRequestId = supportRequestId;
            Content = content;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
        }

        public static SupportRequestMessage Create(SupportRequestId supportRequestId,
            string content,
            DateTime createdAt,
            string createdBy)
        {
            return new(SupportRequestMessageId.CreateUnique(),
                supportRequestId,
                content,
                createdAt, 
                createdBy);
        }

    }
}
