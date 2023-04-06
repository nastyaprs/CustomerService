using CustomerService.Application.Common.Enums;
using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Common.Interfaces.Services;
using CustomerService.Domain.SupportRequest;
using CustomerService.Domain.User.ValueObjects;

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
            string IssueSubject,
            string IssueType,
            string IssueDescription,
            string UrgencyLevel, 
            string customerId)
        {
            //create support request
            var supportRequest = SupportRequest.Create(
                UserId.Create(customerId),
                IssueSubject,
                IssueType,
                IssueDescription,
                UrgencyLevel);

            supportRequest.Status = Status.NotDone.ToString(); 
            supportRequest.CreatedAt = _dateTimeProvider.UtcNow;
            supportRequest.UpdatedAt = _dateTimeProvider.UtcNow;
            
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

            //persist it
            await _supportRequestRepository.Add(supportRequest);

            //save changes to db

            //return support request response
            return new CreateSupportRequestResult(supportRequest.Id.Value,
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
