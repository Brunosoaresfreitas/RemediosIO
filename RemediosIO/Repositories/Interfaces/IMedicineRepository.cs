using RemediosIO.Models;

namespace RemediosIO.Repositories.Interfaces
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllAsync();
        Task<Medicine> GetByIdAsync(int id);
        Task DeleteAsync(Medicine medicine);
        Task CreateAsync(Medicine medicine);
        Task SaveChangesAsync();
    }
}
