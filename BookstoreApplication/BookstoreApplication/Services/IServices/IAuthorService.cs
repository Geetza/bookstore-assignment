using BookstoreApplication.Domain;
using BookstoreApplication.DTOs.Response;

namespace BookstoreApplication.Services.IServices
{
    public interface IAuthorService
    {
        Task<PaginatedResultDto<AuthorDto>> GetPagedAuthorsAsync(int page, int pageSize);
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author?> UpdateAuthorAsync(int id, Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
