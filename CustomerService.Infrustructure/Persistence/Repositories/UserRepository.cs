using CustomerService.Application.Common.Enums;
using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Infrustructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CustomerServiceDBContext _customerServiceDBContext;

        public UserRepository(CustomerServiceDBContext customerServiceDBContext)
        {
            _customerServiceDBContext = customerServiceDBContext;
        }

        public async Task Add(User user)
        {
            await _customerServiceDBContext.Users.AddAsync(user);
            await _customerServiceDBContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetCustomers()
        {
            var data = await _customerServiceDBContext.Users
                .Include(x => x.SupportRequests)
                .ThenInclude(x => x.SupportRequestMessages)
                .Where(x => x.Role == Role.Customer.ToString())
                .ToListAsync();

            return data;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _customerServiceDBContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserById(long id)
        {
            return await _customerServiceDBContext.Users
                .FirstAsync(u => u.Id == id);
        }
    }
}
