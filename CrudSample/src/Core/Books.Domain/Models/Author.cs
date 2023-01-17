using Books.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Models
{
    public class Author
    {
        protected Author()
        {
        }
        public Author(string name)
        {
            Name validateName = new Name(name);

            FullName = validateName;
        }
        public int Id { get; set; }
        public Name FullName { get; }
        public virtual ICollection<BookEntity> Books { get; init; } = new List<BookEntity>();
    }
}
