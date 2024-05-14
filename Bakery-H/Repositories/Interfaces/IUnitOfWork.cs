using Bakery_Homework.Repositories.Interfaces;

namespace Bakery_H.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAngajatiRepository Angajati { get; set; }
        ILocatiiRepository Locatii { get; set; }
        IUserRepository User { get; set; }
    }
}
