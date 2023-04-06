
using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Domain.SupportRequest;

namespace CustomerService.Infrustructure.Persistence
{
    public class SupportRequestRepository : ISupportRequestRepository
    {
        private static readonly List<SupportRequest> _supportRequests = new();

        public async Task Add(SupportRequest supportRequest)
        {
            await Task.CompletedTask;

            _supportRequests.Add(supportRequest);
        }

        public async Task<SupportRequest> Get(Guid id)
        {
            await Task.CompletedTask;

            return _supportRequests
                .First(request => request.Id.Value == id);
        }
    }
}
