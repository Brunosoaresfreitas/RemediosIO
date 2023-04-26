using Microsoft.EntityFrameworkCore;
using RemediosIO.Models;
using RemediosIO.Persistence;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly RemediosIoContext _remediosContext;

        public MedicineRepository(RemediosIoContext remediosContext)
        {
            _remediosContext = remediosContext;
        }

        public async Task CreateAsync(Medicine medicine)
        {
            await _remediosContext.Medicines.AddAsync(medicine);
            await _remediosContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Medicine medicine)
        {
            _remediosContext.Medicines.Remove(medicine);
            await _remediosContext.SaveChangesAsync();
        }

        public async Task<List<Medicine>> GetAllAsync()
        {
            return await _remediosContext.Medicines.ToListAsync();
        }

        public async Task<Medicine> GetByIdAsync(int id)
        {
            return await _remediosContext
                .Medicines
                .Include(f => f.IdPharmacies)
                .Include(s => s.IdSuppliers)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _remediosContext.SaveChangesAsync();
        }
    }
}
