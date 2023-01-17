using Books.Domain.Models;
using Books.Repository;
using Persistence;

namespace Books.Persistence.Repositories
{
    public class AuthorRepository:Repository<Author>,IAuthorRepository
    {
        public AuthorRepository(ProjectContext context):base(context)
        {
        }
    }
}
