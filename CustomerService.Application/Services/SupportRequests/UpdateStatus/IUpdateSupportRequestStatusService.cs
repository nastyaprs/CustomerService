namespace CustomerService.Application.Services.SupportRequests.UpdateStatus
{
    public interface IUpdateSupportRequestStatusService
    {
        Task UpdateStatus(long requestId, string status, string statusDetails);
    }
}
