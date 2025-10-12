using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;
        private readonly AuthorService _authorService;
        private readonly PublisherService _publisherService;

        public BookService(BookRepository bookRepository, AuthorService authorService, PublisherService publisherService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetOneBookAsync(id);
        }

        public async Task<Book?> CreateBookAsync(Book book)
        {
            var author = await _authorService.GetAuthorByIdAsync(book.AuthorId);
            if (author == null) return null;

            var publisher = await _publisherService.GetPublisherByIdAsync(book.PublisherId);
            if (publisher == null) return null;

            book.Author = author;
            book.Publisher = publisher;

            return await _bookRepository.AddBookAsync(book);
        }

        public async Task<Book?> UpdateBookAsync(Book book)
        {
            var existingBook = await _bookRepository.GetOneBookAsync(book.Id);
            if (existingBook == null) return null;

            var author = await _authorService.GetAuthorByIdAsync(book.AuthorId);
            if (author == null) return null;

            var publisher = await _publisherService.GetPublisherByIdAsync(book.PublisherId);
            if (publisher == null) return null;

            book.Author = author;
            book.Publisher = publisher;

            return await _bookRepository.UpdateBookAsync(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var existingBook = await _bookRepository.GetOneBookAsync(id);
            if (existingBook == null)
                return false;

            return await _bookRepository.DeleteBookAsync(id);
        }
    }
}
