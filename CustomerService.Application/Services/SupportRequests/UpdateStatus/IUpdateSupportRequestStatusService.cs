namespace CustomerService.Application.Services.SupportRequests.UpdateStatus
{
    public interface IUpdateSupportRequestStatusService
    {
        Task UpdateStatus(string requestId, string status, string statusDetails);
    }
}
