using Books.Domain.Dto;

namespace Book.ClientSdk.Create
{
    public class CreateAuthorResponse : Response<AuthorDto>
    {
        public CreateAuthorResponse(AuthorDto successData) : base(successData)
        {
        }
        public CreateAuthorResponse(int error) : base(error)
        {
        }
        protected CreateAuthorResponse()
        {

        }
    }
}