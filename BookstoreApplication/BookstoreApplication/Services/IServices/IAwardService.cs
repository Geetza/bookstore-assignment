using BookstoreApplication.Models;

namespace BookstoreApplication.Services.IServices
{
    public interface IAwardService
    {
        Task<List<Award>> GetAllAsync();
        Task<Award?> GetAwardByIdAsync(int id);
        Task<Award> CreateAuthorAsync(Award award);
        Task<Award> UpdateAuthorAsync(Award award);
        Task<bool> DeleteAuthorAsync(int id);

    }
}
