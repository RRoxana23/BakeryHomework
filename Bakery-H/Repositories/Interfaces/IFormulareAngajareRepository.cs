using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Repositories.Interfaces
{
    public interface IFormulareAngajareRepository : IRepository<FormulareAngajare>
    {
        Task<IEnumerable<FormulareAngajare>> GetAllWithLocatiiAsync();
        Task<FormulareAngajare> GetByIdWithLocatieAsync(int id);
        void Delete(int id);
    }
}
