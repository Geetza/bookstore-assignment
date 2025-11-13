using BookstoreApplication.Domain;

namespace BookstoreApplication.Domain.IRepositories
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllPublishersAsync();
        IQueryable<Publisher> GetAllPublishers();
        Task<Publisher?> GetOnePublisherAsync(int id);
        Task<Publisher> AddPublisherAsync(Publisher publisher);
        Task<Publisher> UpdatePublisherAsync(Publisher publisher);
        Task<bool> DeletePublisherAsync(int id);

    }
}
