using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Repositories
{
    public class LocatiiRepository : ILocatiiRepository
    {
        private readonly DbContext _dbContext;

        public LocatiiRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Locatii>> GetAll()
        {
            return await _dbContext.Set<Locatii>().ToListAsync();
        }

        public async Task<Locatii> GetById(int id)
        {
            return await _dbContext.Set<Locatii>().FindAsync(id);
        }

        public async Task Add(Locatii locatie)
        {
            await _dbContext.Set<Locatii>().AddAsync(locatie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Locatii locatie)
        {
            _dbContext.Entry(locatie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var locatie = await _dbContext.Set<Locatii>().FindAsync(id);
            if (locatie != null)
            {
                _dbContext.Set<Locatii>().Remove(locatie);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
