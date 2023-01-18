using Books.Application.Services.Interfaces;
using Books.Application.Services;
using Persistence;
using Books.Domain.Dto;
using Books.Repository;
using Book.ClientSdk;

namespace Book.IntegerationTest.BookServices
{
    public class BookServicesTest : IClassFixture<ApplicationTestFixture>
    {
        private readonly IBookService _manager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProjectContext _dbContext;

        public BookServicesTest(ApplicationTestFixture fixture)
        {
            _dbContext = fixture.ApplicationDbContext;
            _unitOfWork = new UnitOfWork(_dbContext);
            _manager = new BookService(_unitOfWork);
        }

        [Theory]
        [InlineData(1, "Freedom", 2.35, "This book is very good.")]
        [InlineData(1, "C# Programming", 20, "This book is useful.")]
        public void should_create_book_if_book_data_is_valid(int id, string title, decimal price, string des)
        {

            var inputDto = new BookDto()
            {
                AuthorId = id,
                Title = title,
                Price = price,
                Description = des
            };

            var result = _manager.Create(inputDto).GetAwaiter().GetResult();

            Assert.NotEqual(0, result.Data.Id);
            Assert.True(result.Success);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void should_returns_book_if_book_id_is_valid(int id)
        {
            var result = _manager.GetById(id).GetAwaiter().GetResult();

            Assert.True(result.Success);
            Assert.NotEqual(0, result.Data.Id);
        }

        [Theory]
        [InlineData("Book1")]
        [InlineData("Book2")]
        public void should_returns_book_if_book_title_is_valid(string title)
        {
            var result = _manager.GetByTitle(title).GetAwaiter().GetResult();

            Assert.True(result.Success);
            Assert.NotEqual(0, result.Data.Id);
        }
    }
}
