using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
    }
}
