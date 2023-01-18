using Books.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Book.IntegerationTest
{
    public class ApplicationTestFixture : IDisposable
    {
        public ProjectContext ApplicationDbContext { get; private set; }

        public ApplicationTestFixture()
        {
            SetServices();
            FillMockData();
        }
        private void SetServices()
        {
            var dbName = $"CrudTestDb_{DateTime.Now.ToFileTimeUtc()}";
            var dbContextOptions = new DbContextOptionsBuilder<ProjectContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            ApplicationDbContext = new ProjectContext(dbContextOptions);
        }

        private void FillMockData()
        {
            FillMockAuthor();
            FillMockBook();
        }

        private void FillMockAuthor()
        {
            Author author = new Author("Bahareh");

            ApplicationDbContext.Authors.Add(author);

            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        }

        private void FillMockBook()
        {
            BookEntity book1 = new BookEntity("Book1", 32.25m, " ", 1);
            BookEntity book2 = new BookEntity("Book2", 86.25m, " ", 1);

            ApplicationDbContext.Books.Add(book1);
            ApplicationDbContext.Books.Add(book2);

            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            ApplicationDbContext.Dispose();
        }
    }
}
