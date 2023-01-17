namespace Books.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository AuthorRepository {get;}
        IBookRepository BookRepository { get;}
        Task<int> Save();
    }
}
