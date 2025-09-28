using System.Threading.Tasks;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherRepository _publisherRepository;

        public PublishersController(PublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        // GET: api/publishers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishers = await _publisherRepository.GetAllPublishersAsync();
            return Ok(publishers);
        }

        // GET api/publishers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var publisher = await _publisherRepository.GetOnePublisherAsync(id);
            if (publisher == null)
                return NotFound();

            return Ok(publisher);
        }

        // POST api/publishers
        [HttpPost]
        public async Task<IActionResult> Post(Publisher publisher)
        {
            var createdPublisher = await _publisherRepository.AddPublisherAsync(publisher);
            return Ok(createdPublisher);
        }

        // PUT api/publishers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Publisher publisher)
        {
            if (id != publisher.Id)
                return BadRequest("Publisher ID mismatch.");

            var existingPublisher = await _publisherRepository.GetOnePublisherAsync(id);
            if (existingPublisher == null)
                return NotFound();

            var updatedPublisher = await _publisherRepository.UpdatePublisherAsync(publisher);
            return Ok(updatedPublisher);
        }

        // DELETE api/publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var publisher = await _publisherRepository.GetOnePublisherAsync(id);
            if (publisher == null)
                return NotFound();

            await _publisherRepository.DeletePublisherAsync(id);
            return NoContent();
        }
    }
}
