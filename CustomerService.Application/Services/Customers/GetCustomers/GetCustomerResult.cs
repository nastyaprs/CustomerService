using CustomerService.Application.Services.SupportRequests.GetSupportRequest;

namespace CustomerService.Application.Services.Customers.GetCustomers
{
    public record GetCustomerResult
    (
        string FirstName,
        string LastName,
        string Email,
        List<GetSupportRequestResult> GetSupportRequests
    );
}
