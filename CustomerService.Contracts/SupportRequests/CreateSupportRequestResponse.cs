namespace CustomerService.Contracts.SupportRequests
{
    public record CreateSupportRequestResponse
    (
        long Id,
        string IssueSubject,
        string IssueType,
        string IssueDescription,
        string UrgencyLevel, 
        DateTime DueDate,
        DateTime? CreatedAt,
        string Status
    );
}
