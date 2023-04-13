using CustomerService.Application.Common.Interfaces.Persistence;

namespace CustomerService.Application.Services.SupportRequests.GetSupportRequest
{
    public class GetSupportRequestService : IGetSupportRequestService
    {
        private readonly ISupportRequestRepository _supportRequestRepository;

        public GetSupportRequestService(ISupportRequestRepository supportRequestRepository)
        {
            _supportRequestRepository = supportRequestRepository;
        }

        public async Task<GetSupportRequestResult> Get(long supportRequestId)
        {
            var supportRequest = await _supportRequestRepository.GetSupportRequestById(supportRequestId);

            var response = new GetSupportRequestResult(
                supportRequest.IssueSubject,
                supportRequest.IssueType,
                supportRequest.IssueDescription,
                supportRequest.UrgencyLevel,
                supportRequest.DueDate,
                supportRequest.CreatedAt,
                supportRequest.UpdatedAt,
                supportRequest.Status,
                supportRequest.StatusDetails,
                supportRequest.SupportRequestMessages
                .Select(message => new GetSupportRequestMessages(
                    message.Content,
                    message.CreatedAt,
                    message.CreatedBy))
                .ToList());

            return response;
        }
    }
}
