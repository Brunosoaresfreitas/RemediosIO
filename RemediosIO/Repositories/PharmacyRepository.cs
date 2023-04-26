using Microsoft.EntityFrameworkCore;
using RemediosIO.Models;
using RemediosIO.Persistence;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly RemediosIoContext _context;

        public PharmacyRepository(RemediosIoContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Pharmacy pharmacy)
        {
            await _context.Pharmacies.AddAsync(pharmacy);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pharmacy pharmacy)
        {
            _context.Pharmacies.Remove(pharmacy);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pharmacy>> GetAllAsync()
        {
            return await _context.Pharmacies.ToListAsync();
        }

        public async Task<Pharmacy> GetByIdAsync(int id)
        {
            return await _context
                .Pharmacies
                .Include(c => c.Clients)
                .Include(m => m.IdMedicines)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
