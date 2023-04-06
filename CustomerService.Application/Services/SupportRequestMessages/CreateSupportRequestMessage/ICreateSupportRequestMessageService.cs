namespace CustomerService.Application.Services.SupportRequestMessages.CreateSupportRequestMessage
{
    public interface ICreateSupportRequestMessageService
    {
        Task<CreateSupportRequestMessageResult> CreateMessage(string content, 
            string supportRequestId, 
            string createdBy);
    }
}
