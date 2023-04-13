using CustomerService.Domain.Common.Models;

namespace CustomerService.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public ICollection<SupportRequest> SupportRequests { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
    }
}
