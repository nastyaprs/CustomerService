using CustomerService.Domain.Common.Models;
using CustomerService.Domain.User.ValueObjects;

namespace CustomerService.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        //need to be changed
        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        private readonly List<SupportRequest.SupportRequest> _supportRequests = new();

        public ICollection<SupportRequest.SupportRequest> SupportRequestMessages => _supportRequests.ToList();

        private User(UserId id, 
            string firstName, 
            string lastName,
            string email,
            string password,
            string role,
            DateTime createdAt,
            DateTime updatedAt) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static User Create(UserId userId,
            string firstName,
            string lastName,
            string email,
            string password,
            string role,
            DateTime createdAt,
            DateTime updatedAt)
        {
            return new(UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password,
                role,
                createdAt,
                updatedAt);
        }
    }
}
