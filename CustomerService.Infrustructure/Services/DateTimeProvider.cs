using CustomerService.Application.Common.Interfaces.Services;

namespace CustomerService.Infrustructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
