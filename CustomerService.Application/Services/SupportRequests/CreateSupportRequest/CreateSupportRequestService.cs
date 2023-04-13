using CustomerService.Application.Common.Enums;
using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Common.Interfaces.Services;
using CustomerService.Domain.Entities;

namespace CustomerService.Application.Services.SupportRequests.CreateSupportRequest
{
    public class CreateSupportRequestService : ICreateSupportRequestService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ISupportRequestRepository _supportRequestRepository;

        public CreateSupportRequestService(IDateTimeProvider dateTimeProvider,
            ISupportRequestRepository supportRequestRepository)
        {
            _dateTimeProvider = dateTimeProvider;
            _supportRequestRepository = supportRequestRepository;
        }

        public async Task<CreateSupportRequestResult> CreateSupportRequest(
            string issueSubject,
            string issueType,
            string issueDescription,
            string urgencyLevel, 
            long customerId)
        {
      
            var supportRequest = new SupportRequest {
                IssueSubject = issueSubject,
                IssueType = issueType,
                IssueDescription = issueDescription,
                UrgencyLevel = urgencyLevel,
                CustomerId = customerId
            };

            supportRequest.Status = Status.NotDone.ToString(); 
            
            if(supportRequest.UrgencyLevel == UrgencyLevelEnum.Low.ToString())
            {
                supportRequest.DueDate = _dateTimeProvider.UtcNow.AddHours(48);
            }
            else if(supportRequest.UrgencyLevel == UrgencyLevelEnum.Medium.ToString())
            {
                supportRequest.DueDate = _dateTimeProvider.UtcNow.AddHours(24);
            }
            else if(supportRequest.UrgencyLevel == UrgencyLevelEnum.High.ToString())
            {
                supportRequest.DueDate = _dateTimeProvider.UtcNow.AddHours(4);
            }


            await _supportRequestRepository.AddSupportRequest(supportRequest);

            return new CreateSupportRequestResult(supportRequest.Id,
                supportRequest.IssueSubject,
                supportRequest.IssueType,
                supportRequest.IssueDescription,
                supportRequest.UrgencyLevel,
                supportRequest.DueDate,
                supportRequest.CreatedAt,
                supportRequest.Status);
        }
    }
}
