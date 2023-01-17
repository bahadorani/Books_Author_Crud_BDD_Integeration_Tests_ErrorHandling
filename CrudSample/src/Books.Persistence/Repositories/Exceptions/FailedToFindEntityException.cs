using System.Runtime.Serialization;

namespace Books.Persistence.Repositories.Exceptions
{
    [Serializable]
    public class FailedToFindEntityException : Exception
    {
        public FailedToFindEntityException()
        {
        }

        public FailedToFindEntityException(string? message) : base(message)
        {
        }

        public FailedToFindEntityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToFindEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}