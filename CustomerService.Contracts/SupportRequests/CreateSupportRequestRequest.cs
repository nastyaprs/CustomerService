namespace CustomerService.Contracts.SupportRequests
{
    public record CreateSupportRequestRequest
    (
        string IssueSubject,
        string IssueType,
        string IssueDescription
    );

    public enum UrgencyLevel
    {
        Low,
        Medium,
        High
    }
}
