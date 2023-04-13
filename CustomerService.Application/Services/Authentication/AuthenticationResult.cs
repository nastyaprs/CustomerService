using CustomerService.Domain.Entities;

namespace CustomerService.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
