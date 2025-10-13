using BookstoreApplication.Domain;

namespace BookstoreApplication.Services.IServices
{
    public interface IPublisherService
    {
        Task<List<Publisher>> GetAllPublishersAsync();
        Task<Publisher?> GetPublisherByIdAsync(int id);
        Task<Publisher> CreatePublisherAsync(Publisher publisher);
        Task<Publisher?> UpdatePublisherAsync(Publisher publisher);
        Task<bool> DeletePublisherAsync(int id);
    }
}
