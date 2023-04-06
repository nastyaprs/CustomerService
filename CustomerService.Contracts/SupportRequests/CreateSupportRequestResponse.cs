namespace CustomerService.Contracts.SupportRequests
{
    public record CreateSupportRequestResponse
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
