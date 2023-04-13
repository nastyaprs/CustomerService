using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Common.Interfaces.Services;
using CustomerService.Domain.Entities;

namespace CustomerService.Application.Services.SupportRequestMessages.CreateSupportRequestMessage
{
    public class CreateSupportRequestMessageService : ICreateSupportRequestMessageService
    {
        private readonly ISupportRequestMessageRepository _supportRequestMessageRepository;
        private readonly IUserRepository _userRepository;

        public CreateSupportRequestMessageService(ISupportRequestMessageRepository supportRequestMessageRepository, 
            IUserRepository userRepository)
        {
            _supportRequestMessageRepository = supportRequestMessageRepository;
            _userRepository = userRepository;
        }

        public async Task<CreateSupportRequestMessageResult> CreateMessage(string content, long supportRequestId, long userId)
        {
            var user = await _userRepository.GetUserById(userId);

            var message = new SupportRequestMessage {
                Content = content,
                CreatedBy = $"{user.FirstName} {user.LastName}",
                SupportRequestId = supportRequestId
            };

            
            await _supportRequestMessageRepository.Add(message);

            
            return new CreateSupportRequestMessageResult(message.Content,
                message.CreatedAt,
                message.CreatedBy);
        }
    }
}
