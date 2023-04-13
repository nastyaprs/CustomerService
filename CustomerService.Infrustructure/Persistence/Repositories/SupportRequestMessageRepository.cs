using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Domain.Entities;

namespace CustomerService.Infrustructure.Persistence.Repositories
{
    public class SupportRequestMessageRepository : ISupportRequestMessageRepository
    {
        private readonly CustomerServiceDBContext _customerServiceDBContext;
        public SupportRequestMessageRepository(CustomerServiceDBContext customerServiceDBContext)
        {
            _customerServiceDBContext = customerServiceDBContext;
        }
        public async Task Add(SupportRequestMessage supportRequestMessage)
        {
            await _customerServiceDBContext.SupportRequestMessages.AddAsync(supportRequestMessage);
            await _customerServiceDBContext.SaveChangesAsync();
        }
    }
}
