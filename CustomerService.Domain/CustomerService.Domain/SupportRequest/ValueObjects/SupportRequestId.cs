using CustomerService.Domain.Common.Models;

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
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
