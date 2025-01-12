using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bakery_H.Repositories
{
    public class ComenziRepository : Repository<Comenzi>, IComenziRepository
    {
        public ComenziRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<Comenzi> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Comenzi>()
                .Include(c => c.Client)
                .Include(c => c.MetodaPlata)
                .FirstOrDefaultAsync(c => c.IdComanda == id);
        }

        public async Task<IEnumerable<Comenzi>> GetAllAsync()
        {
            return await _dbContext.Comenzi.ToListAsync();
        }

        public async Task<Clienti> GetClientByUserIdAsync(string userId)
        {
            if (Guid.TryParse(userId, out Guid userIdGuid))
            {
                return await _dbContext.Clienti.FirstOrDefaultAsync(c => c.userId == userIdGuid);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Comenzi>> GetOrdersByClientIdAsync(int clientId)
        {
            return await _dbContext.Comenzi
                .Where(c => c.ClientId == clientId)
                .ToListAsync();
        }
    }
}
