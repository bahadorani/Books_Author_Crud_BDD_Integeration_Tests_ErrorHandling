using Books.Application.Services.Interfaces;
using Books.Application.Services;
using Persistence;
using Books.Domain.Dto;
using Books.Repository;
using Book.ClientSdk;

namespace Book.IntegerationTest.BookServices
{
    public class BookServicesExeptionTest : IClassFixture<ApplicationTestFixture>
    {
        private readonly IBookService _manager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProjectContext _dbContext;

        public BookServicesExeptionTest(ApplicationTestFixture fixture)
        {
            _dbContext = fixture.ApplicationDbContext;
            _unitOfWork = new UnitOfWork(_dbContext);
            _manager = new BookService(_unitOfWork);
        }

        [Fact]
        public void should_return_error_if_bookTitle_is_invalid()
        {

            var inputDto = new BookDto()
            {
                AuthorId = 1,
                Title = "",
                Price = 2.35M,
                Description = ""
            };

            var result = _manager.Create(inputDto).GetAwaiter().GetResult();

            Assert.Equal((int)ErrorCodes.InvalidBookName, result.Error);
            Assert.False(result.Success);
        }

        [Fact]
        public void should_return_error_if_bookTitle_has_lessThan_3_chararcters()
        {

            var inputDto = new BookDto()
            {
                AuthorId = 1,
                Title = "n",
                Price = 2.35M,
                Description = ""
            };

            var result = _manager.Create(inputDto).GetAwaiter().GetResult();

            Assert.Equal((int)ErrorCodes.InvalidBookName, result.Error);
            Assert.False(result.Success);
        }

        [Fact]
        public void should_return_error_if_bookTitle_is_duplicate()
        {

            var inputDto = new BookDto()
            {
                AuthorId = 1,
                Title = "Book1",
                Price = 2.35M,
                Description = ""
            };

            var result = _manager.Create(inputDto).GetAwaiter().GetResult();

            Assert.Equal((int)ErrorCodes.DuplicateBookByTitle, result.Error);
            Assert.False(result.Success);
        }

        [Fact]
        public void should_return_error_if_AuthorId_is_not_exists()
        {

            var inputDto = new BookDto()
            {
                AuthorId = 5,
                Title = "Book1",
                Price = 2.35M,
                Description = ""
            };

            var result = _manager.Create(inputDto).GetAwaiter().GetResult();

            Assert.Equal((int)ErrorCodes.InvalidAuthorName, result.Error);
            Assert.False(result.Success);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void should_returns_error_if_book_id_is_invalid(int id)
        {
            var result = _manager.GetById(id).GetAwaiter().GetResult();

            Assert.Equal((int)ErrorCodes.BookWasNotFound, result.Error);
            Assert.False(result.Success);
        }

        [Theory]
        [InlineData("Book5")]
        [InlineData("Book6")]
        public void should_returns_error_if_book_title_is_invalid(string title)
        {
            var result = _manager.GetByTitle(title).GetAwaiter().GetResult();

            Assert.Equal((int)ErrorCodes.BookWasNotFound, result.Error);
            Assert.False(result.Success);
        }
    }
}
