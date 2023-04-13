namespace CustomerService.Application.Services.SupportRequests.CreateSupportRequest
{
    public interface ICreateSupportRequestService
    {
        Task<CreateSupportRequestResult> CreateSupportRequest(
            string IssueSubject,
            string IssueType,
            string IssueDescription,
            string UrgencyLevel,
            long customerId);
    }
}
