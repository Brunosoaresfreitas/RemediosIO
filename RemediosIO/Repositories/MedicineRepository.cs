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

        public async Task<List<Medicine>> GetAllAsync()
        {
            return await _remediosContext.Medicines.ToListAsync();
        }
    }
}
