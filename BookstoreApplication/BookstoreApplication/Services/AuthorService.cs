using BookstoreApplication.Domain;
using BookstoreApplication.Domain.IRepositories;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Services.IServices;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        // UPDATE DELETE I GETONE
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET ALL
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }

        // GET ONE
        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            
            var author = await _authorRepository.GetOneAuthorAsync(id);
            if (author == null)
                throw new NotFoundException(id);
            return author;
        }

        // ADD
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            return await _authorRepository.AddAuthorAsync(author);
        }

        // UPDATE
        public async Task<Author?> UpdateAuthorAsync(int id, Author author)
        {
            if (id != author.Id)
                throw new BadRequestException("Id value is invalid");
            var existingAuthor = await _authorRepository.GetOneAuthorAsync(id);
            if (existingAuthor == null)
            {
                throw new NotFoundException(id);
            }

            existingAuthor.FullName = author.FullName;
            existingAuthor.DateOfBirth = author.DateOfBirth;
            existingAuthor.Biography = author.Biography;
            existingAuthor.AuthorAwards = author.AuthorAwards;

            return await _authorRepository.UpdateAuthorAsync(existingAuthor);
        }

        // DELETE
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var existing = await _authorRepository.GetOneAuthorAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            return await _authorRepository.DeleteAuthorAsync(id);
        }
    }
}
