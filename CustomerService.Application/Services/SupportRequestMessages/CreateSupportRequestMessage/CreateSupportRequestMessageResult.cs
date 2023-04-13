
namespace CustomerService.Application.Services.SupportRequestMessages.CreateSupportRequestMessage
{
    public record CreateSupportRequestMessageResult
    (
        string Content,
        DateTime? CreatedAt,
        string CreatedBy
    );
}
