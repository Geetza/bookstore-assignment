using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class PublisherService
    {
        private readonly PublisherRepository _publisherRepository;

        public PublisherService(PublisherRepository publisherRepository)
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
            return await _publisherRepository.GetOnePublisherAsync(id);
        }

        // ADD
        public async Task<Publisher> CreatePublisherAsync(Publisher publisher)
        {
            return await _publisherRepository.AddPublisherAsync(publisher);
        }

        // UPDATE
        public async Task<Publisher?> UpdatePublisherAsync(Publisher publisher)
        {
            var existingPublisher = await _publisherRepository.GetOnePublisherAsync(publisher.Id);
            if (existingPublisher == null)
                return null;

            return await _publisherRepository.UpdatePublisherAsync(publisher);
        }

        // DELETE
        public async Task<bool> DeletePublisherAsync(int id)
        {
            var existing = await _publisherRepository.GetOnePublisherAsync(id);
            if (existing == null) 
                return false;

            return await _publisherRepository.DeletePublisherAsync(id);
        }
    }
}
