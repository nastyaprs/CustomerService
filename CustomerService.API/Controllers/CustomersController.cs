using CustomerService.Application.Services.Customers.GetCustomers;
using CustomerService.Contracts.Customers;
using CustomerService.Contracts.SupportRequests;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGetCustomersService _getCustomersService;

        public CustomersController(IGetCustomersService getCustomersService)
        {
            _getCustomersService = getCustomersService;
        }

        [HttpGet("get_customers")]
        public async Task<IActionResult> GetCustomers(UrgencyLevel? urgencyLevel, Status? status)
        {
            var result = await _getCustomersService.GetCustomers(urgencyLevel.ToString(), status.ToString());

            var response = MakeResponse(result);

            return Ok(response);
        }
        
        private GetCustomersResponse MakeResponse(List<GetCustomerResult> list)
        {
            var response = new GetCustomersResponse(
                list.Select(customer => new GetCustomer(
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.GetSupportRequests.Select(request => new GetSupportRequestResponse(
                        request.IssueSubject,
                        request.IssueType,
                        request.IssueDescription,
                        request.UrgencyLevel,
                        request.DueDate,
                        request.CreatedAt,
                        request.UpdatedAt,
                        request.Status,
                        request.StatusDetails,
                        request.GetSupportRequestMessages.Select(message => new GetSupportRequestMessages(
                            message.Content,
                            message.CreatedAt,
                            message.CreatedBy))
                        .ToList()))
                    .ToList()))
                .ToList());

            return response;
        }
    }
}
