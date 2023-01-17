using Book.AcceptanceTest.Model;
using Books.Domain.Dto;


namespace Book.AcceptanceTest.Drivers
{
    public class BookContext
    {
        public BookDto BookDtoContext { get; set; } = new();
        public AuthorDto AuthorDtoContext { get; set; } = new();
        public string ErrorCode { get; set; } = null!;
        public bool ErrorStatus { get; set; } = false;
    }
}
