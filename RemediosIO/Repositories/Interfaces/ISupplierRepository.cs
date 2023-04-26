using RemediosIO.Models;

namespace RemediosIO.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(int id);
        Task CreateAsync(Supplier supplier);
        Task DeleteAsync(Supplier supplier);
        Task SaveChangesAsync();
    }
}
