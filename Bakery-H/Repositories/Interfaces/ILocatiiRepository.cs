using Bakery_Homework.Models;

namespace Bakery_H.Repositories.Interfaces
{
    public interface ILocatiiRepository: IRepository<Locatii>
    {
        Task<IEnumerable<Locatii>> GetAll();
        Task<Locatii> GetById(int id);

        void Delete(int id);
    }
}