using RemediosIO.Models;

namespace RemediosIO.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task CreateAsync(Client client);
        Task DeleteAsync(Client client);
        Task SaveChangesAsync();
    }
}
