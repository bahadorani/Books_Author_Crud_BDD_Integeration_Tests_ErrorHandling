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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet(Routes.GetAllAuthors)]
        public ActionResult<GetAllAuthorResponse> GetAllAuthors()
        {
            return _authorService.GetAll();
        }

        [HttpGet(Routes.GetAuthorById)]
        public async Task<ActionResult<GetAuthorResponse>> GetAuthorById(int id)
        {
            return await _authorService.GetById(id);
        }

        [HttpGet(Routes.GetAuthorByName)]
        public ActionResult<GetAuthorResponse> GetAuthorByName(string name)
        {
            return _authorService.GetByName(name);
        }

        [HttpPost(Routes.CreateAuthor)]
        public async Task<ActionResult<CreateAuthorResponse>> CreateAuthor(AuthorDto book)
        {
            return await _authorService.Create(book);
        }

        [HttpDelete(Routes.DeleteAuthor)]
        public async Task DeleteBook(int id)
        {
            await _authorService.Delete(id);
        }
    }
}
