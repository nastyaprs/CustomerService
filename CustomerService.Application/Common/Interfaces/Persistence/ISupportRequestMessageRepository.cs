using CustomerService.Domain.Entities;

namespace CustomerService.Application.Common.Interfaces.Persistence
{
    public interface ISupportRequestMessageRepository
    {
        Task Add(SupportRequestMessage supportRequestMessage);
    }
}
