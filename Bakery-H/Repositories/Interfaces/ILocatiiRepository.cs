using Bakery_Homework.Models;

namespace Bakery_H.Repositories.Interfaces
{
    public interface ILocatiiRepository
    {
        Task<IEnumerable<Locatii>> GetAll();
        Task<Locatii> GetById(int id);
        Task Add(Locatii locatie);
        Task Update(Locatii locatie);
        Task Delete(int id);
    }
}