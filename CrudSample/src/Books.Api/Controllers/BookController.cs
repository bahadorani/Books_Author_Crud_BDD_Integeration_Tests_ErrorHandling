using Book.ClientSdk;
using Book.ClientSdk.Create;
using Books.Application.Services.Interfaces;
using Books.Domain.Dto;
using Customer.ClientSdk.Get;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet(Routes.GetAllBooks)]
        public ActionResult<GetAllBookResponse> GetAllBooks()
        {
            return _bookService.GetAll();
        }

        [HttpGet(Routes.GetBookById)]
        public async Task<ActionResult<GetBookResponse>> GetBookById(int id)
        {
            return await _bookService.GetById(id);
        }

        [HttpGet(Routes.GetBookByTitle)]
        public async Task<ActionResult<GetBookResponse>> GetBookByTitle(string title)
        {
            return await _bookService.GetByTitle(title);
        }

        [HttpPost(Routes.CreateBook)]
        public async Task<ActionResult<CreateBookResponse>> CreateBook(BookDto book)
        {
            return await _bookService.Create(book);
        }

        [HttpDelete(Routes.DeleteBook)]
        public async Task DeleteBook(int id)
        {
            await _bookService.Delete(id);
        }
    }
}