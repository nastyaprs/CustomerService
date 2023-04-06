
namespace CustomerService.Application.Services.Customers.GetCustomers
{
    public interface IGetCustomersService
    {
        Task<List<GetCustomerResult>> GetCustomers(string? urgencyLevel, string? status);
    }
}
