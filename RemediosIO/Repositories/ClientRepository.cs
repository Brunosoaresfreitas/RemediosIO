using Microsoft.EntityFrameworkCore;
using RemediosIO.Models;
using RemediosIO.Persistence;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly RemediosIoContext _context;

        public ClientRepository(RemediosIoContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task DeleteAsync(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context
                .Clients
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
