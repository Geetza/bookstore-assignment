using BookstoreApplication.Domain;
using BookstoreApplication.Domain.IRepositories;
using BookstoreApplication.Exceptions;
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
            var reward = await _awardRepository.GetOneAwardAsync(id);
            if (reward == null)
                throw new NotFoundException(id);
            return reward;
        }

        // ADD
        public async Task<Award> CreateAwardAsync(Award award)
        {
            return await _awardRepository.AddAwardAsync(award);
        }

        // UPDATE
        public async Task<Award> UpdateAwardAsync(int id, Award award)
        {
            if (id != award.Id)
                throw new BadRequestException("Id value is invalid");
            var existingAward = await _awardRepository.GetOneAwardAsync(id);
            if (existingAward == null)
            {
                throw new NotFoundException(id);
            }

            existingAward.Name = award.Name;
            existingAward.Description = award.Description;
            existingAward.CreatedDate = DateTime.UtcNow;

            return await _awardRepository.UpdateAwardAsync(existingAward);
        }

        // DELETE
        public async Task<bool> DeleteAwardAsync(int id)
        {
            var existingAward = await _awardRepository.GetOneAwardAsync(id);
            if (existingAward == null)
                throw new NotFoundException(id);
            return await _awardRepository.DeleteAwardAsync(id);
        }
    }
}
