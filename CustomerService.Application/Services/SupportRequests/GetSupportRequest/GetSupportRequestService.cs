using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Domain.SupportRequest;

namespace CustomerService.Application.Services.SupportRequests.GetSupportRequest
{
    public class GetSupportRequestService : IGetSupportRequestService
    {
        private readonly ISupportRequestRepository _supportRequestRepository;

        public GetSupportRequestService(ISupportRequestRepository supportRequestRepository)
        {
            _supportRequestRepository = supportRequestRepository;
        }

        public async Task<GetSupportRequestResult> Get(string supportRequestId)
        {
            var supportRequest = await _supportRequestRepository.Get(Guid.Parse(supportRequestId));

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
