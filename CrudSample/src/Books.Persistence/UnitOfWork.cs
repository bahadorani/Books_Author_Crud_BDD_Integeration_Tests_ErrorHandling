using Books.Persistence.Repositories;
using Books.Repository;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _context;

        public UnitOfWork(ProjectContext context)
        {
            _context = context;
            BookRepository = new BookRepository(_context);
            AuthorRepository = new AuthorRepository(_context);
        }

        public IBookRepository BookRepository { get; set; }
        public IAuthorRepository AuthorRepository { get; set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}