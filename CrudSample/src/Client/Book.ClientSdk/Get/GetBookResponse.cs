using Book.ClientSdk;
using Books.Domain.Dto;

namespace Customer.ClientSdk.Get
{
    public class GetBookResponse : Response<BookDto>
    {
        public GetBookResponse(BookDto successData) : base(successData)
        {
        }
        public GetBookResponse(int error) : base(error)
        {
        }
        protected GetBookResponse()
        { }
    }
}
