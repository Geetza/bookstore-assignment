using BookstoreApplication.Domain;
using BookstoreApplication.DTOs.Response;
using BookstoreApplication.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            return Ok(await _bookService.GetAllBooksAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDto>> GetOne(int id)
        {
            return Ok(await _bookService.GetBookByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            return Ok(await _bookService.CreateBookAsync(book));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            return Ok(await _bookService.UpdateBookAsync(id, book));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
