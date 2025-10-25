using BookstoreApplication.Domain;

namespace BookstoreApplication.Services.IServices
{
    public interface IAwardService
    {
        Task<List<Award>> GetAllAsync();
        Task<Award?> GetAwardByIdAsync(int id);
        Task<Award> CreateAwardAsync(Award award);
        Task<Award> UpdateAwardAsync(int id, Award award);
        Task<bool> DeleteAwardAsync(int id);

    }
}
