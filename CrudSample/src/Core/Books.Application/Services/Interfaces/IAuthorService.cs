using Book.ClientSdk.Create;
using Books.Domain.Dto;
using Customer.ClientSdk.Get;

namespace Books.Application.Services.Interfaces
{
    public interface IAuthorService
    {
        GetAllAuthorResponse GetAll();
        Task<GetAuthorResponse> GetById(int id);
        GetAuthorResponse GetByName(string name);
        Task<CreateAuthorResponse> Create(AuthorDto author);
        Task Delete(int id);
    }
}
