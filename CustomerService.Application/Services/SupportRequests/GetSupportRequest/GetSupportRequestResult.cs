namespace CustomerService.Application.Services.SupportRequests.GetSupportRequest
{
    public record GetSupportRequestResult
    (
        string IssueSubject,
        string IssueType,
        string IssueDescription,
        string UrgencyLevel,
        DateTime DueDate,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Status,
        string StatusDetails,
        List<GetSupportRequestMessages> GetSupportRequestMessages
    );

    public record GetSupportRequestMessages
    (
        string Content,
        DateTime CreatedAt,
        string CreatedBy
    );
}
