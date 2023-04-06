
using CustomerService.Domain.SupportRequest;

namespace CustomerService.Application.Services.SupportRequests.GetSupportRequest
{
    public interface IGetSupportRequestService
    {
        Task<GetSupportRequestResult> Get(string supportRequestId);
    }
}
