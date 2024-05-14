using Bakery_H.Models;
using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using System.Collections.Generic;

namespace Bakery_Homework.Repositories.Interfaces
{
    public interface IAngajatiRepository : IRepository<Angajati>
    {
        IEnumerable<FormulareAngajare> GetAllFormulareAngajare();
        IEnumerable<Locatii> GetAllLocatii();
        IEnumerable<User> GetAllUsers();
        Task<IEnumerable<Angajati>> GetAllAsync();
        Task<Angajati> GetByIdAsync(int id);
        Task CreateAsync(Angajati angajati);
        bool AngajatiExists(int id);
    }
}
