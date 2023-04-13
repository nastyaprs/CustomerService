using CustomerService.Domain.Entities;

namespace CustomerService.Application.Common.Interfaces.Persistence
{
    public interface ISupportRequestRepository
    {
        Task AddSupportRequest(SupportRequest supportRequest);

        Task<SupportRequest> GetSupportRequestById(long id);

        Task SaveChangesAsync();
    }
}
