using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Repositories;
using Bakery_Homework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bakery_H.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        public ILocatiiRepository Locatii { get; set; }
        public IUserRepository User { get; set; }
        public IAngajatiRepository Angajati { get; set; }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;

            Locatii = new LocatiiRepository(dbContext);
            User = new UserRepository(dbContext);
            Angajati = new AngajatiRepository(dbContext);
        }
    }
}
