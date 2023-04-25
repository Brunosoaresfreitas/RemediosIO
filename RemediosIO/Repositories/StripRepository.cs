using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RemediosIO.Models;
using RemediosIO.Persistence;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Repositories
{
    public class StripRepository : IStripRepository
    {
        private readonly RemediosIoContext _context;

        public StripRepository(RemediosIoContext context)
        {
            _context = context;
        }    
        public async Task CreateAsync(Strip strip)
        {
            await _context.Strips.AddAsync(strip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Strip strip)
        {
            _context.Strips.Remove(strip);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Strip>> GetAllAsync()
        {
            return await _context.Strips.ToListAsync();
        }

        public async Task<Strip> GetByIdAsync(int id)
        {
            return await _context
                .Strips
                .Include(m => m.Medicines)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
