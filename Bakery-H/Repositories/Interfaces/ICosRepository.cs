using Bakery_H.Models;
using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using System.Collections.Generic;

namespace Bakery_Homework.Repositories.Interfaces
{
    public interface ICosRepository : IRepository<ProdusInCos>
    {
        List<ProdusInCos> GetCartItems(string sessionKey);
        string SaveCartItems(List<ProdusInCos> cartItems);
    }
}
