using Book.ClientSdk;
using Books.Domain.Dto;

namespace Customer.ClientSdk.Get
{
    public class GetAllBookResponse : Response<List<BookDto>>
    {
        public GetAllBookResponse(List<BookDto> successData) : base(successData)
        {
        }
        public GetAllBookResponse(int error) : base(error)
        {
        }
        protected GetAllBookResponse()
        {

        }
    }
}
