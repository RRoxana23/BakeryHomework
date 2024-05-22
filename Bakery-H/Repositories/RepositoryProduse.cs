using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Repositories
{
    public class ProduseRepository : Repository<Produse>, IProduseRepository
    {
        public ProduseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Produse>> GetAll()
        {
            return await _dbContext.Set<Produse>().ToListAsync();
        }

        public async Task<Produse> GetById(int id)
        {
            return await _dbContext.Set<Produse>().FindAsync(id);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Set<Produse>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<Produse>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}
