using Bakery_H.Models;
using Bakery_H.Repositories;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bakery_Homework.Repositories
{
    public class CosRepository : Repository<ProdusInCos>, ICosRepository
    {
        public CosRepository(DbContext dbContext) : base(dbContext) { }

        public List<ProdusInCos> GetCartItems(string cartData)
        {
            return string.IsNullOrEmpty(cartData)
                ? new List<ProdusInCos>()
                : JsonConvert.DeserializeObject<List<ProdusInCos>>(cartData);
        }

        public string SaveCartItems(List<ProdusInCos> cartItems)
        {
            return JsonConvert.SerializeObject(cartItems);
        }
    }
}
