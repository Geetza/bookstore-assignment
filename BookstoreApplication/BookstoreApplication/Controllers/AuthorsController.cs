using BookstoreApplication.Models;
using BookstoreApplication.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST api/authors
        [HttpPost]
        public async Task<IActionResult> Post(Author author)
        {
            var createdAuthor = await _authorService.CreateAuthorAsync(author);
            return Ok(createdAuthor);
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            var updatedAuthor = await _authorService.UpdateAuthorAsync(author);
            if (updatedAuthor == null)
            {
                return NotFound();
            }
            return Ok(updatedAuthor);
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _authorService.DeleteAuthorAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
