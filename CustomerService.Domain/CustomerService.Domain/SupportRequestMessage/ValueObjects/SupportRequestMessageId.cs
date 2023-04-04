using CustomerService.Domain.Common.Models;

namespace CustomerService.Domain.SupportRequestMessage.ValueObjects
{
    public sealed class SupportRequestMessageId : ValueObject
    {
        public Guid Value { get; }

        private SupportRequestMessageId(Guid value)
        {
            Value = value;
        }

        public static SupportRequestMessageId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
