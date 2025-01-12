using Bakery_H.Models;
using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using System.Collections.Generic;

namespace Bakery_Homework.Repositories.Interfaces
{
    public interface IDetaliiComandaRepository : IRepository<DetaliiComanda>
    {
        Task<DetaliiComanda> GetByComandaIdAsync(int comandaId);
    }
}
