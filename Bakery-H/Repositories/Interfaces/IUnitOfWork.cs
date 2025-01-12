using Bakery_Homework.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Bakery_H.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProduseRepository Produse { get; }
        ILocatiiRepository Locatii { get; }
        IUserRepository User { get; }
        IAngajatiRepository Angajati { get; }
        IFormulareAngajareRepository FormulareAngajare { get; }
        IClientiRepository Clienti { get; }
        ICosRepository Cos { get; }
        Task SaveChangesAsync();
    }
}
