using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Services.Interfaces
{
    public interface ILocatiiService
    {
        Task<IEnumerable<Locatii>> GetAllLocatiiAsync();
        Task<Locatii> GetLocatieByIdAsync(int id);
        Task CreateLocatieAsync(Locatii locatie);
        Task UpdateLocatieAsync(Locatii locatie);
        void DeleteLocatie(int id);
    }
}
