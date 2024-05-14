using Bakery_H.Models;
using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_Homework.Services.Interfaces
{
    public interface IAngajatiService
    {
        Task<IEnumerable<Angajati>> GetAllAsync();
        Task<Angajati> GetByIdAsync(int id);
        Task CreateAsync(Angajati angajati);
        Task UpdateAsync(Angajati angajati);
        Task DeleteAsync(int id);
        bool AngajatiExists(int id);
        IEnumerable<FormulareAngajare> GetAllFormulareAngajare();
        IEnumerable<Locatii> GetAllLocatii();
        IEnumerable<User> GetAllUsers();
    }
}
