using Bakery_H.Models;
using Bakery_H.Repositories;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bakery_Homework.Repositories
{
    public class DetaliiComandaRepository : Repository<DetaliiComanda>, IDetaliiComandaRepository
    {
        public DetaliiComandaRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<DetaliiComanda> GetByComandaIdAsync(int comandaId)
        {
            return await _dbContext.Set<DetaliiComanda>()
                .Include(d => d.Produs)
                .Include(d => d.Comanda)
                .FirstOrDefaultAsync(d => d.ComandaId == comandaId);
        }
    }
}
