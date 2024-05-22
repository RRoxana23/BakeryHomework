using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Services.Interfaces
{
    public interface IProduseService
    {
        Task<IEnumerable<Produse>> GetAllProduseAsync();
        Task<Produse> GetProdusByIdAsync(int id);
        Task CreateProdusAsync(Produse produs);
        Task UpdateProdusAsync(Produse produs);
        void DeleteProdus(int id);
    }
}
