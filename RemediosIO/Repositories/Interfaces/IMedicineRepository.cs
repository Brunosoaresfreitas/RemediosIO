using RemediosIO.Models;

namespace RemediosIO.Repositories.Interfaces
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllAsync();
    }
}
