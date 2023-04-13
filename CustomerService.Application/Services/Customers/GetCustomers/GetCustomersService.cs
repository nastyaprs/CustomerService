using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Services.SupportRequests.GetSupportRequest;
using CustomerService.Domain.Entities;

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
            var customers = await _userRepository.GetCustomers();

            var response = MakeCustomersResponse(customers);

            if(urgencyLevel != String.Empty)
            {
                response = FilterByUrgencyLevel(response, urgencyLevel);
            }

            if(status != String.Empty)
            {
                response = FilterByStatus(response, status);
            }

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
            var data =  list
                .Select(c => new GetCustomerResult(c.FirstName, c.LastName, c.Email,
                c.GetSupportRequests.Where(r => r.UrgencyLevel == urgencyLevel)
                .ToList()))
                .ToList();

            data.RemoveAll(c => c.GetSupportRequests.Count == 0);

            return data;
        }



        private List<GetCustomerResult> FilterByStatus(List<GetCustomerResult> list, string status)
        {
            var data =  list.Select(c => new GetCustomerResult(c.FirstName, c.LastName,c.Email,
                c.GetSupportRequests.Where(r => r.Status == status).ToList()
            )).ToList();

            data.RemoveAll(c => c.GetSupportRequests.Count == 0);

            return data;
        }

    }
}
