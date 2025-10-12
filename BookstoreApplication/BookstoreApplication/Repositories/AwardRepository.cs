using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class AwardRepository : IAwardRepository
    {
        private AppDbContext _context;

        public AwardRepository(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<Award>> GetAllAwardsAsync()
        {
            return await _context.Awards.ToListAsync();
        }

        // GET ONE
        public async Task<Award?> GetOneAwardAsync(int id)
        {
            return await _context.Awards.FirstOrDefaultAsync(a => a.Id == id);
        }

        // ADD
        public async Task<Award> AddAwardAsync(Award award)
        {
            await _context.AddAsync(award);
            await _context.SaveChangesAsync();
            return award;
        }

        // UPDATE
        public async Task<Award> UpdateAwardAsync(Award award)
        {
            _context.Update(award);
            await _context.SaveChangesAsync();
            return award;
        }

        // DELETE
        public async Task<bool> DeleteAwardAsync(int id)
        {
            var award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return false;
            }

            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
