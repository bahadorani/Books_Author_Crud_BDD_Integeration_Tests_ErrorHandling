namespace Book.ClientSdk
{
    public struct Routes
    {
        public const string GetAllBooks = "/api/getAllBooks";
        public const string GetBookById = "/api/getBookById";
        public const string GetBookByTitle = "/api/getBookByTitle";
        public const string DeleteBook = "/api/deleteBook";
        public const string CreateBook = "/api/createBook";

        public const string GetAllAuthors = "/api/getAllAuthors";
        public const string GetAuthorById = "/api/getAuthorById";
        public const string GetAuthorByName = "/api/getAuthorByName";
        public const string DeleteAuthor = "/api/deleteAuthor";
        public const string CreateAuthor = "/api/createAuthor";
    }

    public class AppConfig
    {
        public string ApiUrl { get; set; }

        public AppConfig()
        {
            ApiUrl = "http://localhost:5024";
        }
    }
}
