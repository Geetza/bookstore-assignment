using BookstoreApplication.Domain;
using BookstoreApplication.Domain.IRepositories;
using BookstoreApplication.Services.IServices;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

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
            return await _authorRepository.GetOneAuthorAsync(id);
        }

        // ADD
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            return await _authorRepository.AddAuthorAsync(author);
        }

        // UPDATE
        public async Task<Author?> UpdateAuthorAsync(Author author)
        {
            var existingAuthor = await _authorRepository.GetOneAuthorAsync(author.Id);
            if (existingAuthor == null)
            {
                return null;
            }
            return await _authorRepository.UpdateAuthorAsync(author);
        }

        // DELETE
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var existing = await _authorRepository.GetOneAuthorAsync(id);
            if (existing == null)
                return false;

            return await _authorRepository.DeleteAuthorAsync(id);
        }
    }
}
