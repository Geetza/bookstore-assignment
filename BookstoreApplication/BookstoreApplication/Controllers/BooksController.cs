using System.Threading.Tasks;
using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {   
        private readonly BookRepository _bookRepository;
        private readonly AuthorRepository _authorRepository;
        private readonly PublisherRepository _publisherRepository;

        public BooksController(BookRepository bookRepository, AuthorRepository authorRepository, PublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var book = await _bookRepository.GetOneBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            // kreiranje knjige je moguće ako je izabran postojeći autor
            var author = await _authorRepository.GetOneAuthorAsync(book.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            // kreiranje knjige je moguće ako je izabran postojeći izdavač
            var publisher = await _publisherRepository.GetOnePublisherAsync(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest();
            }

            book.Author = author;
            book.Publisher = publisher;

            var createdBook = await _bookRepository.AddBookAsync(book);
            return Ok(createdBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = await _bookRepository.GetOneBookAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            // izmena knjige je moguca ako je izabran postojeći autor
            var author = await _authorRepository.GetOneAuthorAsync(book.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            // izmena knjige je moguca ako je izabran postojeći izdavač
            var publisher = await _publisherRepository.GetOnePublisherAsync(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest();
            }

            book.Author = author;
            book.Publisher = publisher;

            var updatedBook = await _bookRepository.UpdateBookAsync(book);
            return Ok(updatedBook);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetOneBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookRepository.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
