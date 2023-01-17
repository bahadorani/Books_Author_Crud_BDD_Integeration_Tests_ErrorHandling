using Book.ClientSdk;
using Books.Domain.Dto;

namespace Customer.ClientSdk.Get
{
    public class GetAllAuthorResponse : Response<List<AuthorDto>>
    {
        public GetAllAuthorResponse(List<AuthorDto> successData) : base(successData)
        {
        }
        public GetAllAuthorResponse(int error) : base(error)
        {
        }
        protected GetAllAuthorResponse()
        {

        }
    }
}
