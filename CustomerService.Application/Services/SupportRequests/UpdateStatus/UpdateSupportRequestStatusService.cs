using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Common.Interfaces.Services;

namespace CustomerService.Application.Services.SupportRequests.UpdateStatus
{
    public class UpdateSupportRequestStatusService : IUpdateSupportRequestStatusService
    {
        private readonly ISupportRequestRepository _supportRequestRepository;

        public UpdateSupportRequestStatusService(ISupportRequestRepository supportRequestRepository)
        {
            _supportRequestRepository = supportRequestRepository;
        }

        public async Task UpdateStatus(long requestId, string status, string statusDetails)
        {
            var supportRequest = await _supportRequestRepository.GetSupportRequestById(requestId);

            supportRequest.Status = status;
            supportRequest.StatusDetails = statusDetails;

            await _supportRequestRepository.SaveChangesAsync();
        }
    }
}
