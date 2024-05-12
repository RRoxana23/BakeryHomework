using Bakery_Homework.Models;

namespace Bakery_H.Services.Interfaces
{
    public interface ILocatiiService
    {
        Task<IEnumerable<Locatii>> GetAllLocatii();
        Task<Locatii> GetLocatieById(int id);
        Task CreateLocatie(Locatii locatie);
        Task UpdateLocatie(Locatii locatie);
        Task DeleteLocatie(int id);
    }
}