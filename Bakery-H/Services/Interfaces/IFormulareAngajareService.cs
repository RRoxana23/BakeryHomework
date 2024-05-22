using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Services.Interfaces
{
    public interface IFormulareAngajareService
    {
        Task<IEnumerable<FormulareAngajare>> GetAllFormulareAsync();
        Task<FormulareAngajare> GetFormularByIdAsync(int id);
        Task CreateFormularAsync(FormulareAngajare formulareAngajare);
        Task UpdateFormularAsync(FormulareAngajare formulareAngajare);
        void DeleteFormular(int id);
    }
}
