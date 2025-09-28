using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class AuthorRepository
    {
        private AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        // GET ONE
        public async Task<Author?> GetOneAuthorAsync(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        // ADD
        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _context.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        // UPDATE
        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            _context.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        // DELETE
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
