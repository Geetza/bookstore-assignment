using BookstoreApplication.Domain;

namespace BookstoreApplication.Services.IServices
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author?> UpdateAuthorAsync(int id, Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
