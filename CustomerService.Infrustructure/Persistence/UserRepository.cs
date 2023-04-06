using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Domain.User;

namespace CustomerService.Infrustructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public async Task Add(User user)
        {
            await Task.CompletedTask;
            _users.Add(user);
        }

        public async Task<List<User>> GetCustomers()
        {
            await Task.CompletedTask;
            return _users;
        }


        public async Task<User?> GetUserByEmail(string email)
        {
            await Task.CompletedTask;
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
