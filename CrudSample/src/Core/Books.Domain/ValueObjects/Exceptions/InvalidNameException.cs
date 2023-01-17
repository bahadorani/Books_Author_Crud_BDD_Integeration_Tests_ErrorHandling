using System.Runtime.Serialization;

namespace Books.Domain.ValueObjects.Exceptions
{
    [Serializable]
    internal class InvalidNameException : Exception
    {
        public InvalidNameException()
        {
        }

        public InvalidNameException(string? message) : base(message)
        {
        }

        public InvalidNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}