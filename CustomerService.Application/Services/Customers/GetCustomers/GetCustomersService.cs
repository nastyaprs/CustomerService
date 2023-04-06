using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Services.SupportRequests.GetSupportRequest;
using CustomerService.Domain.User;

namespace CustomerService.Application.Services.Customers.GetCustomers
{
    public class GetCustomersService : IGetCustomersService
    {
        private readonly IUserRepository _userRepository;

        public GetCustomersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetCustomerResult>> GetCustomers(string? urgencyLevel, string? status)
        {
            //get from db list of customers
            var customers = await _userRepository.GetCustomers();

            //return into a response model
            var response = MakeCustomersResponse(customers);

            //filter by urgency level
            if(urgencyLevel != null)
            {
                response = FilterByUrgencyLevel(response, urgencyLevel);
            }

            //filter by status
            if(status != null)
            {
                response = FilterByStatus(response, status);
            }

            //return
            return response;
        }

        private List<GetCustomerResult> MakeCustomersResponse(List<User> users)
        {
            List<GetCustomerResult> listOfCustomers = new();

            foreach(var user in users)
            {
                var customer = new GetCustomerResult(
                user.FirstName,
                user.LastName,
                user.Email,
                user.SupportRequests.Select(request => new GetSupportRequestResult(
                    request.IssueType,
                    request.IssueSubject,
                    request.IssueDescription,
                    request.UrgencyLevel,
                    request.DueDate,
                    request.CreatedAt,
                    request.UpdatedAt,
                    request.Status,
                    request.StatusDetails,
                    request.SupportRequestMessages.Select(message => new GetSupportRequestMessages(
                        message.Content,
                        message.CreatedAt,
                        message.CreatedBy))
                    .ToList()))
                .ToList());

                listOfCustomers.Add(customer);
            }

            return listOfCustomers;
        }

        private List<GetCustomerResult> FilterByUrgencyLevel(List<GetCustomerResult> list, string urgencyLevel)
        {
            foreach (var customer in list)
            {
                for (int i = 0; i < customer.GetSupportRequests.Count(); i++)
                {
                    if (customer.GetSupportRequests[i].UrgencyLevel != urgencyLevel)
                    {
                        customer.GetSupportRequests.Remove(customer.GetSupportRequests[i]);
                    }
                }
            }

            return list;
        }

        private List<GetCustomerResult> FilterByStatus(List<GetCustomerResult> list, string status)
        {
            foreach (var customer in list)
            {
                for (int i = 0; i < customer.GetSupportRequests.Count(); i++)
                {
                    if (customer.GetSupportRequests[i].Status != status)
                    {
                        customer.GetSupportRequests.Remove(customer.GetSupportRequests[i]);
                    }
                }
            }

            return list;
        }
    }
}
