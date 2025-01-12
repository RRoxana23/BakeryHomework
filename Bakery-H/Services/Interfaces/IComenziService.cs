using Bakery_H.Models;
using Bakery_Homework.DTOs;
using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_Homework.Services.Interfaces
{
    public interface IComenziService
    {
        string PlaseazaComanda(ComandaDTO comandaDto);
        Task<List<ComandaDTO>> GetOrdersByUserIdAsync(string userId);
        Task<int?> GetClientIdByUserIdAsync(string userId);
        Task<IEnumerable<Comenzi>> GetOrdersByClientIdAsync(int clientId);
    }
}
