using Microsoft.EntityFrameworkCore;
using RemediosIO.Models;
using RemediosIO.Persistence;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly RemediosIoContext _context;

        public SupplierRepository(RemediosIoContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await _context
                .Suppliers
                .Include(m => m.Medicines)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
