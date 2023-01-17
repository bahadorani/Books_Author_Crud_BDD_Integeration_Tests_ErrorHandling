using Books.Domain.ValueObjects.Exceptions;

namespace Books.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        protected Name()
        {
        }

        public Name(string value)
        {
            ValidateName(value);
            Value = value;
        }

        public string Value { get; set; }

        private void ValidateName(string value)
        {
            value = value.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidNameException("Invalid name");
            }

            if (value.Length < 3)
                throw new InvalidNameException("The name should have more than 3 characters.");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
