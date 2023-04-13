using CustomerService.Domain.Common.Models;

namespace CustomerService.Domain.Entities
{
    public sealed class SupportRequestMessage : BaseEntity
    {
        public long Id { get; set; }
        public long SupportRequestId { get; set; }
        public SupportRequest SupportRequest { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
    }
}
