namespace CustomerService.Contracts.SupportRequests
{
    public record GetSupportRequestResponse
    (
        string IssueSubject,
        string IssueType,
        string IssueDescription,
        string UrgencyLevel,
        DateTime DueDate,
        DateTime? CreatedAt,
        DateTime? UpdatedAt,
        string Status,
        string StatusDetails,
        List<GetSupportRequestMessages> SupportRequestMessages
    );

    public record GetSupportRequestMessages
    (
        string Content,
        DateTime? CreatedAt,
        string CreatedBy
    );
}
