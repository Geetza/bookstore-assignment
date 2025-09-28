using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService(AuthorRepository authorRepository)
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
        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            return await _authorRepository.UpdateAuthorAsync(author);
        }

        // DELETE
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            return await _authorRepository.DeleteAuthorAsync(id);
        }
    }
}
