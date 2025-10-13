using BookstoreApplication.Domain;

namespace BookstoreApplication.Domain.IRepositories
{
    public interface IAwardRepository
    {
        Task<List<Award>> GetAllAwardsAsync();
        Task<Award?> GetOneAwardAsync(int id);
        Task<Award> AddAwardAsync(Award award);
        Task<Award> UpdateAwardAsync(Award award);
        Task<bool> DeleteAwardAsync(int id);

    }
}
