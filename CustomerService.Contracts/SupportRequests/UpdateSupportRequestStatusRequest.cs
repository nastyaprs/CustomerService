namespace CustomerService.Contracts.SupportRequests
{
    public record UpdateSupportRequestStatusRequest
    (
        string StatusDetails
    );

    public enum Status
    {
        NotDone,
        InProgress,
        Done
    }
   
}
