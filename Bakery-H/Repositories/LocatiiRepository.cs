using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Repositories
{
    public class LocatiiRepository : Repository<Locatii>, ILocatiiRepository
    {

        public LocatiiRepository(DbContext dbContext): base(dbContext)
        {
            
        }

        public async Task<IEnumerable<Locatii>> GetAll()
        {
            return await _dbContext.Set<Locatii>().ToListAsync();
        }

        public async Task<Locatii> GetById(int id)
        {
            return await _dbContext.Set<Locatii>().FindAsync(id);
        }
    }
}
