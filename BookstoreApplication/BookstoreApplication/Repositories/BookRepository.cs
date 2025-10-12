using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        // GET ONE
        public async Task<Book?> GetOneBookAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // ADD
        public async Task<Book> AddBookAsync(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        // UPDATE
        public async Task<Book> UpdateBookAsync(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook == null)
            {
                throw new ArgumentException($"Book with ID {book.Id} not found.");
            }

            // Update only the properties that should be updated
            existingBook.Title = book.Title;
            existingBook.PageCount = book.PageCount;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN;
            existingBook.AuthorId = book.AuthorId;
            existingBook.PublisherId = book.PublisherId;

            await _context.SaveChangesAsync();
            return existingBook;
        }

        // DELETE
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
