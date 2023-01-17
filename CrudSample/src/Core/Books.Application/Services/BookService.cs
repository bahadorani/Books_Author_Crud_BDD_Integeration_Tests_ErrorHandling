using Book.ClientSdk;
using Book.ClientSdk.Create;
using Books.Application.Services.Interfaces;
using Books.Domain.Dto;
using Books.Domain.Models;
using Books.Repository;
using Customer.ClientSdk.Get;

namespace Books.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateBookResponse> Create(BookDto book)
        {
            try
            {
                if (!CheckAuthor(book.AuthorId))
                    return new CreateBookResponse((int)ErrorCodes.InvalidAuthorName);
                if (CheckBookExists(book.Title))
                    return new CreateBookResponse((int)ErrorCodes.DuplicateBookByTitle);


                BookEntity model = new BookEntity(book.Title, book.Price, book.Description, book.AuthorId);

                await _unitOfWork.BookRepository.Add(model);
                await _unitOfWork.Save();

                return new(convert(model));
            }
            catch
            {
                return new((int)ErrorCodes.InvalidBookName);
            }
        }

        public async Task Delete(int id)
        {

            BookEntity model = await _unitOfWork.BookRepository.Get(id);

            _unitOfWork.BookRepository.Remove(model);
            await _unitOfWork.Save();
        }

        public GetAllBookResponse GetAll()
        {
            return new(_unitOfWork.BookRepository.GetAll().Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title.Value,
                Description = b.Description,
                AuthorName = b.BookAuthor.FullName.Value
            }).ToList());
        }

        public async Task<GetBookResponse> GetById(int id)
        {
            try
            {
                BookEntity model = await _unitOfWork.BookRepository.GetById(id);

                return new(new BookDto
                {
                    Id = model.Id,
                    Title = model.Title.Value,
                    Description = model.Description,
                    AuthorName = model.BookAuthor.FullName.Value
                });
            }
            catch
            {
                return new((int)ErrorCodes.BookWasNotFound);
            }
        }

        public async Task<GetBookResponse> GetByTitle(string title)
        {
            try
            {
                BookEntity model = await _unitOfWork.BookRepository.GetByTitle(title);

                return new(convert(model));
            }
            catch
            {
                return new((int)ErrorCodes.BookWasNotFound);
            }
        }

        private BookDto convert(BookEntity book)
        {
            BookDto result = new BookDto
            {
                Id = book.Id,
                Title = book.Title.Value,
                Description = book.Description,
                AuthorName = book.BookAuthor.FullName.Value,
                Price = book.Price.Value
            };
            return result;
        }

        private bool CheckAuthor(int id)
        {
            try
            {
                var result = _unitOfWork.AuthorRepository.SingleOrDefault(a => a.Id == id);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckBookExists(string name)
        {
            try
            {
                var result = _unitOfWork.BookRepository.SingleOrDefault(a => a.Title.Value.Trim().ToLower() == name.Trim().ToLower());

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
