using CustomerService.Domain.SupportRequest;

namespace CustomerService.Application.Common.Interfaces.Persistence
{
    public interface ISupportRequestRepository
    {
        Task Add(SupportRequest supportRequest);

        Task<SupportRequest> Get(Guid id);
    }
}
