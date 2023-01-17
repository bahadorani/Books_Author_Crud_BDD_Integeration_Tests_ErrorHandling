using Book.ClientSdk;
using Book.ClientSdk.Create;
using Books.Application.Services.Interfaces;
using Books.Domain.Dto;
using Books.Domain.Models;
using Books.Repository;
using Customer.ClientSdk.Get;

namespace Books.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAuthorResponse> Create(AuthorDto author)
        {
            try
            {
                if (CheckAuthorExists(author.FullName))
                    return new((int)ErrorCodes.DuplicateAuthorByName);

                Author model = new Author(author.FullName);

                await _unitOfWork.AuthorRepository.Add(model);
                await _unitOfWork.Save();

                return new(Convert(model));
            }
            catch
            {
                return new((int)ErrorCodes.InvalidAuthorName);
            }
        }

        public async Task Delete(int id)
        {
            Author? model = await _unitOfWork.AuthorRepository.Get(id);

            _unitOfWork.AuthorRepository.Remove(model);
            await _unitOfWork.Save();
        }

        public GetAllAuthorResponse GetAll()
        {
            return new(_unitOfWork.AuthorRepository.GetAll().Select(a => new AuthorDto
            {
                Id = a.Id,
                FullName = a.FullName.Value
            }).ToList());
        }

        public async Task<GetAuthorResponse> GetById(int id)
        {
            try
            {
                Author model = await _unitOfWork.AuthorRepository.Get(id);

                return new(Convert(model));
            }
            catch
            {
                return new((int)ErrorCodes.AuthorWasNotFound);
            }
        }

        public GetAuthorResponse GetByName(string name)
        {
            try
            {
                Author model = _unitOfWork.AuthorRepository.Find(b => b.FullName.Value.Trim().ToLower() == name.ToLower().Trim()).First();

                return new(Convert(model));
            }
            catch
            {
                return new((int)ErrorCodes.AuthorWasNotFound);
            }
        }

        private AuthorDto Convert(Author author)
        {
            AuthorDto model = new AuthorDto
            {
                Id = author.Id,
                FullName = author.FullName.Value
            };

            return model;
        }

        private bool CheckAuthorExists(string name)
        {
            try
            {
                var result = _unitOfWork.AuthorRepository.SingleOrDefault(a => a.FullName.Value.Trim().ToLower() == name.Trim().ToLower());
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
