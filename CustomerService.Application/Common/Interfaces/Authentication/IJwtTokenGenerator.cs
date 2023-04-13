using CustomerService.Domain.Entities;

namespace CustomerService.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
