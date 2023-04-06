using CustomerService.Domain.Common.Models;
using CustomerService.Domain.User.ValueObjects;

namespace CustomerService.Domain.SupportRequest.ValueObjects
{
    public sealed class SupportRequestId : ValueObject
    {
        public Guid Value { get; }

        private SupportRequestId(Guid value)
        {
            Value = value;
        }

        public static SupportRequestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static SupportRequestId Create(string value)
        {
            return new(Guid.Parse(value));
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
