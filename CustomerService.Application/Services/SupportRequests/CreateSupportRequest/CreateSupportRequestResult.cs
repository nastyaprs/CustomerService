namespace CustomerService.Application.Services.SupportRequests.CreateSupportRequest
{
    public record CreateSupportRequestResult
    (
        Guid Id,
        string IssueSubject,
        string IssueType,
        string IssueDescription,
        string UrgencyLevel,
        DateTime DueDate,
        DateTime CreatedAt,
        string Status
    );
}
