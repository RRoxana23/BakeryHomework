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

        public void Delete(int id)
        {
            var entity = _dbContext.Set<Locatii>().Find(id);
            if (entity != null)
            {
                // First, delete related records in FormulareAngajare
                var relatedRecords = _dbContext.Set<FormulareAngajare>().Where(f => f.LocatieId == id).ToList();
                _dbContext.Set<FormulareAngajare>().RemoveRange(relatedRecords);

                // Then, delete the location
                _dbContext.Set<Locatii>().Remove(entity);

                _dbContext.SaveChanges();
            }
        }


    }
}
