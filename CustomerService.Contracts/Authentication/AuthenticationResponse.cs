namespace CustomerService.Contracts.Authentication
{
    public record AuthenticationResponse
    (
        long Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
