using BookstoreApplication.Domain;
using BookstoreApplication.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/publishers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _publisherService.GetAllPublishersAsync());
        }

        // GET api/publishers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _publisherService.GetPublisherByIdAsync(id));
        }

        // POST api/publishers
        [HttpPost]
        public async Task<IActionResult> Post(Publisher publisher)
        {
            return Ok(await _publisherService.CreatePublisherAsync(publisher));
        }

        // PUT api/publishers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Publisher publisher)
        {
            return Ok(await _publisherService.UpdatePublisherAsync(id, publisher));
        }

        // DELETE api/publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _publisherService.DeletePublisherAsync(id);
            return NoContent();
        }
    }
}
