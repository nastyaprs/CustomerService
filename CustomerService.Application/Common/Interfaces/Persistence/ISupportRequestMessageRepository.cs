using CustomerService.Domain.SupportRequestMessage.Entities;

namespace CustomerService.Application.Common.Interfaces.Persistence
{
    public interface ISupportRequestMessageRepository
    {
        Task Add(SupportRequestMessage supportRequestMessage);
    }
}
