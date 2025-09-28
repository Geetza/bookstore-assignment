using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class PublisherRepository
    {
        private AppDbContext _context;

        public PublisherRepository(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<Publisher>> GetAllPublishersAsync()
        {
            return await _context.Publishers.ToListAsync();
        }

        // GET ONE
        public async Task<Publisher?> GetOnePublisherAsync(int id)
        {
            return await _context.Publishers.FirstOrDefaultAsync(p => p.Id == id);
        }

        // ADD
        public async Task<Publisher> AddPublisherAsync(Publisher publisher)
        {
            await _context.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        // UPDATE
        public async Task<Publisher> UpdatePublisherAsync(Publisher publisher)
        {
            _context.Update(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        // DELETE
        public async Task<bool> DeletePublisherAsync(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return false;
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
