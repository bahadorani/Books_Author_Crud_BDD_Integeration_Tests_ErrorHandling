using Book.ClientSdk.Create;
using Books.Domain.Dto;
using Customer.ClientSdk.Get;

namespace Books.Application.Services.Interfaces
{
    public interface IBookService
    {
        GetAllBookResponse GetAll();
        Task<GetBookResponse> GetById(int id);
        Task<GetBookResponse> GetByTitle(string title);
        Task<CreateBookResponse> Create(BookDto book);
        Task Delete(int id);
    }
}
