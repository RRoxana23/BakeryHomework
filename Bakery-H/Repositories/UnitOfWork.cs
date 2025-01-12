using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories;
using Bakery_Homework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bakery_H.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        public IProduseRepository Produse { get; set; }
        public ILocatiiRepository Locatii { get; set; }
        public IUserRepository User { get; set; }
        public IAngajatiRepository Angajati { get; set; }
        public IFormulareAngajareRepository FormulareAngajare { get; set; }
        public IClientiRepository Clienti { get; set; }
        public ICosRepository Cos { get; set; }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            Produse = new ProduseRepository(dbContext);
            Locatii = new LocatiiRepository(dbContext);
            User = new UserRepository(dbContext);
            Angajati = new AngajatiRepository(dbContext);
            FormulareAngajare = new FormulareAngajareRepository(dbContext);
            Clienti = new ClientiRepository(dbContext);
            Cos = new CosRepository(dbContext);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
