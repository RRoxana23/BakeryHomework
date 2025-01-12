using Bakery_H.Models;
using Bakery_Homework.DTOs;
using Bakery_Homework.Models;
using Bakery_Homework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Bakery_H.Controllers
{
    public class CosController : Controller
    {
        private const string CartSessionKey = "CartItems";
        private readonly ICosService _cosService;

        public CosController(ICosService cosService)
        {
            _cosService = cosService;
        }

        public IActionResult Index()
        {
            var cartData = HttpContext.Session.GetString(CartSessionKey);
            var cartItems = _cosService.GetCartItems(cartData);
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AdaugaInCos([FromBody] ProdusInCos produs)
        {
            var cartData = HttpContext.Session.GetString(CartSessionKey);
            var updatedCartData = _cosService.AddToCart(cartData, produs);

            HttpContext.Session.SetString(CartSessionKey, updatedCartData);
            return Json(new { success = true, message = "Produs adăugat în coș." });
        }

        [HttpPost]
        public IActionResult ActualizeazaCantitate([FromBody] ProdusInCos produs)
        {
            var cartData = HttpContext.Session.GetString(CartSessionKey);
            var updatedCartData = _cosService.UpdateQuantity(cartData, produs);

            HttpContext.Session.SetString(CartSessionKey, updatedCartData);
            return Json(new { success = true, message = "Cantitate actualizată." });
        }

        [HttpPost]
        public IActionResult StergeDinCos(int idProdus)
        {
            var cartData = HttpContext.Session.GetString(CartSessionKey);
            var updatedCartData = _cosService.RemoveFromCart(cartData, idProdus);

            HttpContext.Session.SetString(CartSessionKey, updatedCartData);
            return Json(new { success = true, message = "Produs eliminat din coș." });
        }

        [HttpPost]
        public IActionResult GolesteCos()
        {
            var updatedCartData = _cosService.ClearCart();
            HttpContext.Session.SetString(CartSessionKey, updatedCartData);
            return Json(new { success = true, message = "Coș golit cu succes." });
        }
    }
}
