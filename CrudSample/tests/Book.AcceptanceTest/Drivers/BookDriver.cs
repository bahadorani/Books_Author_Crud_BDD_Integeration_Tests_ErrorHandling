using Book.AcceptanceTest.Model;
using Book.ClientSdk;
using Book.ClientSdk.Create;
using Book.ClientSdk.Helper;
using Books.Domain.Dto;
using Customer.ClientSdk.Get;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow.Assist;

namespace Book.AcceptanceTest.Drivers
{
    public class BookDriver
    {
        private readonly HttpClient _httpClient;
        public readonly BookContext SenarioContext;

        public BookDriver(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
            SenarioContext = new BookContext();
        }

        public void SetCustomerInfo(Table table)
        {
            var customers = table.CreateInstance<BookDto>();
            SenarioContext.BookDtoContext = customers;
        }

        public async Task CreateBookWithInformation(Table table)
        {
            BookDto createBook = table.CreateInstance<BookDto>();

            HttpResponseMessage request = await _httpClient.PostAsJsonAsync(Routes.CreateBook, createBook);

            await GetCreateBookInfo(request);
        }

        public async Task CreateAuthorWithInformation(Table table)
        {
            AuthorDto createAuthor = table.CreateInstance<AuthorDto>();

            HttpResponseMessage request = await _httpClient.PostAsJsonAsync(Routes.CreateAuthor, createAuthor);

            await GetCreateAuthorInfo(request);
        }

        public async Task<int> AuthorCountWithName(string name)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(Routes.GetBookByTitle+ "?name=" + name);
            return await GetAuthorInfo(result);
        }

        public async Task<int> BookCountWithName(string name)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(Routes.GetBookByTitle + "?title=" + name);
            return await GetBookInfo(result);
        }

        public void SetSystemError(Table table)
        {
            var error = table.CreateSet<BusinessError>();
            var businessErrors = error.ToList();
        }

        private async Task<int> GetBookInfo(HttpResponseMessage request)
        {
            GetBookResponse response = await request.DeserializeAsync<GetBookResponse>();

            if (response.Success && response.Data != null)
            {
                if (response.Data.Id != 0)
                    return 1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

        private async Task<int> GetAuthorInfo(HttpResponseMessage request)
        {
            GetAuthorResponse response = await request.DeserializeAsync<GetAuthorResponse>();

            if (response.Success && response.Data != null)
            {
                if (response.Data.Id != 0)
                    return 1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

        private async Task GetCreateAuthorInfo(HttpResponseMessage request)
        {
            CreateAuthorResponse response = await request.DeserializeAsync<CreateAuthorResponse>();

            if (response.Success && response.Data != null)
            {
                SetAuthorData(response.Data);
            }
            else
            {
                GetError(response.Error);
            }
        }

        private async Task GetCreateBookInfo(HttpResponseMessage request)
        {
            CreateBookResponse response = await request.DeserializeAsync<CreateBookResponse>();

            if (response.Success && response.Data != null)
            {
                SetBookData(response.Data);
            }
            else
            {
                GetError(response.Error);
            }
        }

        private void GetError(int error)
        {
            SenarioContext.ErrorCode = error.ToString();
            SenarioContext.ErrorStatus = true;
        }

        private void SetBookData(BookDto book)
        {
            SenarioContext.BookDtoContext = book;
            SenarioContext.ErrorStatus = false;
        }

        private void SetAuthorData(AuthorDto author)
        {
            SenarioContext.AuthorDtoContext = author;
            SenarioContext.ErrorStatus = false;
        }
    }
}
