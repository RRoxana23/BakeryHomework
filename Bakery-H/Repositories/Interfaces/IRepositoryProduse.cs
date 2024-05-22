using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Repositories.Interfaces
{
    public interface IProduseRepository : IRepository<Produse>
    {
        Task<IEnumerable<Produse>> GetAll();
        Task<Produse> GetById(int id);
        void Delete(int id);
    }
}
