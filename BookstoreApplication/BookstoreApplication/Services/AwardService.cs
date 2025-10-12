using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using BookstoreApplication.Services.IServices;

namespace BookstoreApplication.Services
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepository;

        public AwardService(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
        }

        // GET ALL
        public async Task<List<Award>> GetAllAsync()
        {
            return await _awardRepository.GetAllAwardsAsync();
        }

        // GET ONE
        public async Task<Award?> GetAwardByIdAsync(int id)
        {
            return await _awardRepository.GetOneAwardAsync(id);
        }

        // ADD
        public async Task<Award> CreateAuthorAsync(Award award)
        {
            return await _awardRepository.AddAwardAsync(award);
        }

        // UPDATE
        public async Task<Award> UpdateAuthorAsync(Award award)
        {
            return await _awardRepository.UpdateAwardAsync(award);
        }

        // DELETE
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            return await _awardRepository.DeleteAwardAsync(id);
        }
    }
}
