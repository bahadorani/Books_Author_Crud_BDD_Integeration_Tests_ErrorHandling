using System.Runtime.Serialization;

namespace Books.Persistence.Repositories.Exceptions
{
    [Serializable]
    public class FailedToFindEntityByNameException : Exception
    {
        public string Name;

        public FailedToFindEntityByNameException(string? message) : base(message)
        {
        }

        public FailedToFindEntityByNameException(string? message, string name) : this(message)
        {
            Name = name;
        }

        public FailedToFindEntityByNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToFindEntityByNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}