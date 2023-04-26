using RemediosIO.Models;

namespace RemediosIO.Repositories.Interfaces
{
    public interface IPharmacyRepository
    {
        Task<List<Pharmacy>> GetAllAsync();
        Task<Pharmacy> GetByIdAsync(int id);
        Task DeleteAsync(Pharmacy pharmacy);
        Task CreateAsync(Pharmacy pharmacy);
        Task SaveChangesAsync();
    }
}
