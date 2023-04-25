using RemediosIO.Models;

namespace RemediosIO.Repositories.Interfaces
{
    public interface IStripRepository
    {
        Task<List<Strip>> GetAllAsync();
        Task<Strip> GetByIdAsync(int id);
        Task CreateAsync(Strip strip);
        Task DeleteAsync(Strip strip);
        Task SaveChangesAsync();
    }
}
