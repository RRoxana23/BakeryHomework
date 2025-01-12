using Bakery_H.Models;
using Bakery_Homework.DTOs;
using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_Homework.Services.Interfaces
{
    public interface ICosService
    {
        List<ProdusInCos> GetCartItems(string cartData);
        string AddToCart(string cartData, ProdusInCos produs);
        string UpdateQuantity(string cartData, ProdusInCos produs);
        string RemoveFromCart(string cartData, int idProdus);
        string PlaseazaComanda(ComandaDTO comandaDto);
        string ClearCart();
    }
}
