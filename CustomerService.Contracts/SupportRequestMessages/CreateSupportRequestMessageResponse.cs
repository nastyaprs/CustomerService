namespace CustomerService.Contracts.SupportRequestMessages
{
    public record CreateSupportRequestMessageResponse
    (
        string Content,
        DateTime CreatedAt,
        string CreatedBy
    );
}
