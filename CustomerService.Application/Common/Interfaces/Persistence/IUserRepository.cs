using CustomerService.Domain.Entities;

namespace CustomerService.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetUserById(long id);

        Task<User?> GetUserByEmail(string email);

        Task Add(User user);

        Task<List<User>> GetCustomers();
    }
}
