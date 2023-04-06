using CustomerService.Contracts.SupportRequests;

namespace CustomerService.Contracts.Customers
{
    public record GetCustomersResponse
    (
        List<GetCustomer> Customers
    );

    public record GetCustomer
    (
        string FirstName,
        string LastName,
        string Email,
        List<GetSupportRequestResponse> SupportRequests
    );
}
