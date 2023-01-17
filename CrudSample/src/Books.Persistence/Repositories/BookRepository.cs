using Books.Domain.Dto;
using Books.Domain.Models;
using Books.Persistence.Repositories.Exceptions;
using Books.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Books.Persistence.Repositories
{
    public class BookRepository : Repository<BookEntity>, IBookRepository
    {
        private readonly ProjectContext _context;
        public BookRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        public List<BookDto> GetBooksWithAuthor()
        {
            return _context.Books.Include(a => a.BookAuthor).Select(b => new BookDto
            {
                AuthorName = b.BookAuthor.FullName.Value,
                Description = b.Description,
                Price = b.Price.Value,
                Title = b.Title.Value
            }).ToList();
        }

        public async Task<BookEntity> GetById(int id)
        {
            var result = await _context.Books.Include(b => b.BookAuthor).FirstOrDefaultAsync(m => m.Id == id);

            if (result is null)
                throw new FailedToFindEntityByIdException("The book was not found.", id.ToString());

            return result;
        }

        public async Task<BookEntity> GetByTitle(string name)
        {
            var result = await _context.Books.Include(b => b.BookAuthor).FirstOrDefaultAsync(m => m.Title.Value.Trim().ToLower() == name.Trim().ToLower());

            if (result is null)
                throw new FailedToFindEntityByNameException("The book was not found.", name);

            return result;
        }
    }

}
