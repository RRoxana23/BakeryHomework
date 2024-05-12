using Bakery_H.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bakery_H.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public ILocatiiRepository Locatii { get; set; }
        public IAngajatiRepository Angajati { get; set; }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;

            Locatii = new LocatiiRepository(dbContext);
            Angajati = new AngajatiRepository(dbContext);
        }
    }
}
