using AutoMapper;
using BookstoreApplication.Domain;
using BookstoreApplication.Domain.IRepositories;
using BookstoreApplication.DTOs.Response;
using BookstoreApplication.Services.IServices;

namespace BookstoreApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IAuthorService authorService, IPublisherService publisherService, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
            _publisherService = publisherService;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return _mapper.Map<List<BookDto>>(books).ToList();
        }

        public async Task<BookDetailsDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetOneBookAsync(id);
            return _mapper.Map<BookDetailsDto?>(book);
        }

        public async Task<Book?> CreateBookAsync(Book book)
        {
            var author = await _authorService.GetAuthorByIdAsync(book.AuthorId);
            if (author == null) return null;

            var publisher = await _publisherService.GetPublisherByIdAsync(book.PublisherId);
            if (publisher == null) return null;

            // **Ovo rešava problem sa PostgreSQL timestamp with time zone**
            book.PublishedDate = DateTime.SpecifyKind(book.PublishedDate, DateTimeKind.Utc);

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

            // **Ovo rešava problem sa PostgreSQL timestamp with time zone**
            book.PublishedDate = DateTime.SpecifyKind(book.PublishedDate, DateTimeKind.Utc);

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
