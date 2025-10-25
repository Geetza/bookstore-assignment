using BookstoreApplication.Domain;
using BookstoreApplication.Domain.IRepositories;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Services.IServices;

namespace BookstoreApplication.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        // GET ALL
        public async Task<List<Publisher>> GetAllPublishersAsync()
        {
            return await _publisherRepository.GetAllPublishersAsync();
        }

        // GET ONE
        public async Task<Publisher?> GetPublisherByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetOnePublisherAsync(id);
            if (publisher == null)
                throw new NotFoundException(id);
            return publisher;
        }

        // ADD
        public async Task<Publisher> CreatePublisherAsync(Publisher publisher)
        {
            return await _publisherRepository.AddPublisherAsync(publisher);
        }

        // UPDATE
        public async Task<Publisher?> UpdatePublisherAsync(int id, Publisher publisher)
        {
            if (id != publisher.Id)
                throw new BadRequestException("Invalid Id");

            var existingPublisher = await _publisherRepository.GetOnePublisherAsync(id);

            if (existingPublisher == null)
                throw new NotFoundException(id);

            existingPublisher.Name = publisher.Name;
            existingPublisher.Address = publisher.Address;
            existingPublisher.Website = publisher.Website;

            return await _publisherRepository.UpdatePublisherAsync(existingPublisher);
        }

        // DELETE
        public async Task<bool> DeletePublisherAsync(int id)
        {
            var existing = await _publisherRepository.GetOnePublisherAsync(id);
            if (existing == null)
                throw new NotFoundException(id);

            return await _publisherRepository.DeletePublisherAsync(id);
        }
    }
}
