using BookstoreApplication.Domain;
using BookstoreApplication.DTOs.Response;

namespace BookstoreApplication.Services.IServices
{
    public interface IPublisherService
    {
        Task<List<Publisher>> GetAllPublishersAsync();
        Task<SortedResultDto<PublisherDto>> GetSortedPublishersAsync(string sortBy = "Name", string sortDirection = "asc");
        Task<Publisher?> GetPublisherByIdAsync(int id);
        Task<Publisher> CreatePublisherAsync(Publisher publisher);
        Task<Publisher?> UpdatePublisherAsync(int id, Publisher publisher);
        Task<bool> DeletePublisherAsync(int id);
    }
}
