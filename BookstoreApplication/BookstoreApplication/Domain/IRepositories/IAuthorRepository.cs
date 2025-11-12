using BookstoreApplication.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreApplication.Domain.IRepositories
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAllAuthors();
        Task<Author?> GetOneAuthorAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
