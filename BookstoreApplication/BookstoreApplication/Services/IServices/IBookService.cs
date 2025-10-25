using BookstoreApplication.Domain;
using BookstoreApplication.DTOs.Response;

namespace BookstoreApplication.Services.IServices
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task<BookDetailsDto?> GetBookByIdAsync(int id);
        Task<Book?> CreateBookAsync(Book book);
        Task<Book?> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}
