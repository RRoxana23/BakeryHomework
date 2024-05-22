using Bakery_H.Models;
using Bakery_H.Repositories;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bakery_Homework.Repositories
{
    public class AngajatiRepository : Repository<Angajati>, IAngajatiRepository
    {
        public AngajatiRepository(DbContext dbContext) : base(dbContext) { }

        public IEnumerable<FormulareAngajare> GetAllFormulareAngajare()
        {
            return _dbContext.Set<FormulareAngajare>().ToList();
        }

        public IEnumerable<Locatii> GetAllLocatii()
        {
            return _dbContext.Set<Locatii>().ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Set<User>().ToList();
        }
        public async Task<IEnumerable<Angajati>> GetAllAsync()
        {
            return await _dbContext.Set<Angajati>()
                .Include(a => a.User)
                .Include(a => a.Locatie)
                .ToListAsync();
        }

        public async Task<Angajati> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Angajati>()
                .Include(a => a.User)
                .Include(a => a.Locatie)
                .FirstOrDefaultAsync(a => a.IdAngajat == id);
        }

        public async Task CreateAsync(Angajati angajati)
        {
            await AddAsync(angajati);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<Angajati>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<Angajati>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool AngajatiExists(int id)
        {
            return _dbContext.Set<Angajati>().Any(e => e.IdAngajat == id);
        }
    }
}
