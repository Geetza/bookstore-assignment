using AutoMapper;
using BookstoreApplication.Domain;
using BookstoreApplication.Domain.IRepositories;
using BookstoreApplication.DTOs.Response;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Services.IServices;

namespace BookstoreApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository,
            IAuthorService authorService,
            IPublisherService publisherService,
            IMapper mapper,
            ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
            _publisherService = publisherService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            _logger.LogInformation("Vadim sve knjige iz repoa");
            var books = await _bookRepository.GetAllBooksAsync();
            return _mapper.Map<List<BookDto>>(books).ToList();
        }

        public async Task<BookDetailsDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetOneBookAsync(id);
            if (book == null)
            {
                _logger.LogInformation("Nema knjige pod tim Id-em");
                throw new NotFoundException(id);

            }
            return _mapper.Map<BookDetailsDto?>(book);
        }

        public async Task<Book?> CreateBookAsync(Book book)
        {
            var author = await _authorService.GetAuthorByIdAsync(book.AuthorId);
            if (author == null) throw new NotFoundException(book.AuthorId);

            var publisher = await _publisherService.GetPublisherByIdAsync(book.PublisherId);
            if (publisher == null) throw new NotFoundException(book.PublisherId);

            // **Ovo rešava problem sa PostgreSQL timestamp with time zone**
            book.PublishedDate = DateTime.SpecifyKind(book.PublishedDate, DateTimeKind.Utc);

            book.Author = author;
            book.Publisher = publisher;

            return await _bookRepository.AddBookAsync(book);
        }

        public async Task<Book?> UpdateBookAsync(int id, Book book)
        {
            _logger.LogInformation("Checking if book exists under given Id");
            var existingBook = await _bookRepository.GetOneBookAsync(id);
            if (existingBook == null)
            {
                _logger.LogInformation("No book exists under given Id");
                throw new NotFoundException(id);
            }

            _logger.LogInformation("Checking if author exists under given Id");
            var author = await _authorService.GetAuthorByIdAsync(book.AuthorId);
            if (author == null)
            {
                _logger.LogInformation("Author not found under given Id");
                throw new NotFoundException(book.AuthorId);
            }

            _logger.LogInformation("Checking if publisher exists under given Id");
            var publisher = await _publisherService.GetPublisherByIdAsync(book.PublisherId);
            if (publisher == null)
            {
                _logger.LogInformation("Publisher not found under given Id");
                throw new NotFoundException(book.AuthorId);
            }

            book.PublishedDate = DateTime.SpecifyKind(book.PublishedDate, DateTimeKind.Utc);

            existingBook.Title = book.Title;
            existingBook.PageCount = book.PageCount;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN;
            existingBook.AuthorId = book.AuthorId;
            existingBook.PublisherId = book.PublisherId;

            return await _bookRepository.UpdateBookAsync(existingBook);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var existingBook = await _bookRepository.GetOneBookAsync(id);
            if (existingBook == null)
            {
                _logger.LogWarning($"Attempted to delete non-existent book with Id: {id}");
                throw new NotFoundException(id);
            }

            var result = await _bookRepository.DeleteBookAsync(id);
            _logger.LogInformation($"Book with Id: {id} deleted");
            return result;
        }
    }
}
