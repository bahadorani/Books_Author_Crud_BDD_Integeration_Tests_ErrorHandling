using Book.ClientSdk;
using Books.Domain.Dto;

namespace Customer.ClientSdk.Get
{
    public class GetAuthorResponse : Response<AuthorDto>
    {
        public GetAuthorResponse(AuthorDto successData) : base(successData)
        {
        }
        public GetAuthorResponse(int error) : base(error)
        {
        }
        protected GetAuthorResponse()
        { }
    }
}
