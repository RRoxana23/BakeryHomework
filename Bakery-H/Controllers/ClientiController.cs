using Bakery_H.Services.Interfaces;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Bakery_Homework.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery_H.Controllers
{
    [Route("api/clienti")]
    [ApiController]
    public class ClientiController : ControllerBase
    {
        private readonly IClientiService _clientiService;

        public ClientiController(IClientiService clientiService)
        {
            _clientiService = clientiService;
        }

        [HttpGet("ObtineIdClient")]
        public async Task<IActionResult> GetClientByUserId(Guid userId)
        {
            var client = await _clientiService.GetClientByUserIdAsync(userId);
            if (client == null)
            {
                return NotFound("Client not found");
            }
            return Ok(new { client.IdClient });
        }
    }
}
