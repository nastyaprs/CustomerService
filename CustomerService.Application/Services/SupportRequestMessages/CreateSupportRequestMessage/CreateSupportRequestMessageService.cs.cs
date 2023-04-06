using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Common.Interfaces.Services;
using CustomerService.Domain.SupportRequest.ValueObjects;
using CustomerService.Domain.SupportRequestMessage.Entities;

namespace CustomerService.Application.Services.SupportRequestMessages.CreateSupportRequestMessage
{
    public class CreateSupportRequestMessageService : ICreateSupportRequestMessageService
    {
        private readonly ISupportRequestMessageRepository _supportRequestMessageRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateSupportRequestMessageService(
            ISupportRequestMessageRepository supportRequestMessageRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _supportRequestMessageRepository = supportRequestMessageRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<CreateSupportRequestMessageResult> CreateMessage(string content, string supportRequestId, string createdBy)
        {
            
            var message = SupportRequestMessage.Create(
                SupportRequestId.Create(supportRequestId),
                content,
                _dateTimeProvider.UtcNow,
                createdBy);

            
            await _supportRequestMessageRepository.Add(message);

            
            return new CreateSupportRequestMessageResult(message.Content,
                message.CreatedAt,
                message.CreatedBy);
        }
    }
}
