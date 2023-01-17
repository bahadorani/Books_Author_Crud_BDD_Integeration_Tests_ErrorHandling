using Books.Domain.Dto;
using Books.Domain.Models;

namespace Books.Repository
{
    public interface IBookRepository : IRepository<BookEntity>
    {
        List<BookDto> GetBooksWithAuthor();
        Task<BookEntity> GetById(int id);
        Task<BookEntity> GetByTitle(string name);
    }
}
