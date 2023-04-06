using CustomerService.Domain.User;

namespace CustomerService.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);

        Task Add(User user);

        Task<List<User>> GetCustomers();
    }
}
