using Bakery_Homework.Models;

namespace Bakery_H.Services.Interfaces
{
    public interface ILocatiiService
    {
        Task<IEnumerable<Locatii>> GetAllLocatii();
        Task<Locatii> GetLocatieById(int id);
        void CreateLocatie(Locatii locatie);
        void UpdateLocatie(Locatii locatie);
        void DeleteLocatie(Locatii locatie);
    }
}