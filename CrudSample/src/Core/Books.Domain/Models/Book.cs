using Books.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Domain.Models
{
    public class BookEntity
    {
        protected BookEntity()
        {
        }
        public BookEntity(string title, decimal price, string description, int authorId)
        {
            Money money = new Money(price);
            Name validateName = new Name(title);

            Title = validateName;
            Price = money;
            Description = description;
            AuthorId = authorId;
        }

        public int Id { get; set; }
        public Name Title { get; } = null!;
        public Money Price { get; } = null!;
        public string Description { get; } = null!;
        public int AuthorId { get; }
        [ForeignKey("AuthorId")] 
        public virtual Author BookAuthor { get; init; } = null!;
    }
}
