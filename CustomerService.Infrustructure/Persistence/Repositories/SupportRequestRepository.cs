using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Infrustructure.Persistence.Repositories
{
    public class SupportRequestRepository : ISupportRequestRepository
    {
        private readonly CustomerServiceDBContext _customerServiceDBContext;

        public SupportRequestRepository(CustomerServiceDBContext customerServiceDBContext)
        {
            _customerServiceDBContext = customerServiceDBContext;
        }

        public async Task AddSupportRequest(SupportRequest supportRequest)
        {
            await _customerServiceDBContext.SupportRequests.AddAsync(supportRequest);
            await _customerServiceDBContext.SaveChangesAsync();
        }

        public async Task<SupportRequest> GetSupportRequestById(long id)
        {
            return await _customerServiceDBContext.SupportRequests
                .Include(x => x.SupportRequestMessages)
                .FirstAsync(r => r.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _customerServiceDBContext.SaveChangesAsync();
        }
    }
}
