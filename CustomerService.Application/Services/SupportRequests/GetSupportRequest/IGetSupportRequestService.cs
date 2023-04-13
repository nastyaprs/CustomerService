namespace CustomerService.Application.Services.SupportRequests.GetSupportRequest
{
    public interface IGetSupportRequestService
    {
        Task<GetSupportRequestResult> Get(long supportRequestId);
    }
}
