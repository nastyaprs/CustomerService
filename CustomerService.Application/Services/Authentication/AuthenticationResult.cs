using CustomerService.Domain.User;

namespace CustomerService.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
