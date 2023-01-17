namespace Books.Domain.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public string? AuthorName { get; init; }
        public int AuthorId { get; set; }
    }
}
