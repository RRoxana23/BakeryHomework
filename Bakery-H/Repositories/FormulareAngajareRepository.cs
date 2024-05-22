using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Repositories
{
    public class FormulareAngajareRepository : Repository<FormulareAngajare>, IFormulareAngajareRepository
    {
        private readonly DbContext _dbContext;

        public FormulareAngajareRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FormulareAngajare>> GetAllWithLocatiiAsync()
        {
            return await _dbContext.Set<FormulareAngajare>()
                                   .Include(f => f.Locatie)
                                   .ToListAsync();
        }

        public async Task<FormulareAngajare> GetByIdWithLocatieAsync(int id)
        {
            return await _dbContext.Set<FormulareAngajare>()
                                   .Include(f => f.Locatie)
                                   .FirstOrDefaultAsync(f => f.IdFormular == id);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Set<FormulareAngajare>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<FormulareAngajare>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}
