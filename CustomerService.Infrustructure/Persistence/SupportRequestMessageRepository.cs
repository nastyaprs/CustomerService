using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Domain.SupportRequestMessage.Entities;

namespace CustomerService.Infrustructure.Persistence
{
    public class SupportRequestMessageRepository : ISupportRequestMessageRepository
    {
        private static readonly List<SupportRequestMessage> _supportRequestMessages = new();

        public async Task Add(SupportRequestMessage supportRequestMessage)
        {
            await Task.CompletedTask;
            _supportRequestMessages.Add(supportRequestMessage);
        }
    }
}
