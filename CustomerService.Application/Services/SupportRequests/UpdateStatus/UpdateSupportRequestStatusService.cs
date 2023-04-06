using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Common.Interfaces.Services;

namespace CustomerService.Application.Services.SupportRequests.UpdateStatus
{
    public class UpdateSupportRequestStatusService : IUpdateSupportRequestStatusService
    {
        private readonly ISupportRequestRepository _supportRequestRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public UpdateSupportRequestStatusService(ISupportRequestRepository supportRequestRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _supportRequestRepository = supportRequestRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task UpdateStatus(string requestId, string status, string statusDetails)
        {
            //get support request
            var supportRequest = await _supportRequestRepository.Get(Guid.Parse(requestId));

            //update status
            supportRequest.Status = status;
            supportRequest.StatusDetails = statusDetails;
            supportRequest.UpdatedAt = _dateTimeProvider.UtcNow;

            //save changes to db

        }
    }
}
