using Books.Domain.Dto;

namespace Book.ClientSdk.Create
{
    public class CreateBookResponse : Response<BookDto>
    {
        public CreateBookResponse(BookDto successData) : base(successData)
        {
        }
        public CreateBookResponse(int error) : base(error)
        {
        }
        protected CreateBookResponse()
        {

        }
    }
}
