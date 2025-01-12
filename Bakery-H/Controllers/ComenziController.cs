using Bakery_Homework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bakery_H.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Bakery_Homework.DTOs;
using Bakery_Homework.Services.Interfaces;
using System.Security.Claims;
using Bakery_Homework.Services;

namespace Bakery_H.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComenziController : Controller
    {
        private readonly IComenziService _comenziService;
        private readonly IClientiService _clientiService;

        public ComenziController(IComenziService comenziService, IClientiService clientiService)
        {
            _comenziService = comenziService;
            _clientiService = clientiService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var idClient = await _comenziService.GetClientIdByUserIdAsync(userId);
            if (idClient == null)
            {
                return NotFound("Clientul nu a fost găsit.");
            }

            var orders = await _comenziService.GetOrdersByClientIdAsync(idClient.Value);

            var ordersDTO = orders.Select(order => new ComandaDTO
            {
                ClientId = order.ClientId,
                DataComanda = order.DataComanda.Value,
                TotalPlata = order.TotalPlata
            }).ToList();

            return View(ordersDTO);
        }

        [HttpPost("PlaseazaComanda")]
        public IActionResult PlaseazaComanda([FromBody] ComandaDTO comandaDto)
        {
            try
            {
                var result = _comenziService.PlaseazaComanda(comandaDto);
                return Ok(new { success = true, message = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("GetUserOrders")]
        public async Task<IActionResult> GetUserOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null || !Guid.TryParse(userId, out var userGuid))
            {
                return Unauthorized();
            }

            var client = await _clientiService.GetClientByUserIdAsync(userGuid);
            if (client == null)
            {
                return NotFound("Client not found");
            }

            var orders = await _comenziService.GetOrdersByClientIdAsync(client.IdClient);

            var orderDTOs = orders.Select(order => new ComandaDTO
            {
                ClientId = order.ClientId,
                DataComanda = order.DataComanda.Value,
                TotalPlata = order.TotalPlata
            }).ToList();

            return Ok(orderDTOs);
        }
    }
}
