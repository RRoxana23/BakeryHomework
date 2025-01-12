using Bakery_H.Models;
using Bakery_H.Repositories;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bakery_Homework.Repositories
{
    public class ClientiRepository : Repository<Clienti>, IClientiRepository
    {
        public ClientiRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<Clienti> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.Set<Clienti>()
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.userId == userId);
        }
    }
}
