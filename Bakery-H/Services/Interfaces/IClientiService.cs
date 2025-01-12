using Bakery_H.Models;
using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_Homework.Services.Interfaces
{
    public interface IClientiService
    {
        Task<Clienti> GetClientByUserIdAsync(Guid userId);
    }
}
