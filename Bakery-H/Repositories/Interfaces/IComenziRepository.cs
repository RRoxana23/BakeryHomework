using Bakery_H.Models;
using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bakery_Homework.Repositories.Interfaces
{
    public interface IComenziRepository : IRepository<Comenzi>
    {
        Task<Comenzi> GetByIdAsync(int id);
        Task<IEnumerable<Comenzi>> GetAllAsync();
        Task<Clienti> GetClientByUserIdAsync(string userId);
        Task<IEnumerable<Comenzi>> GetOrdersByClientIdAsync(int clientId);

    }
}
