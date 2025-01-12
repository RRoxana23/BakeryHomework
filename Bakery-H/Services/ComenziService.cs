using Bakery_H.Models;
using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Bakery_Homework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Bakery_Homework.DTOs;

namespace Bakery_Homework.Services
{
    public class ComenziService : IComenziService
    {
        private readonly IComenziRepository _comenziRepository;
        private readonly IDetaliiComandaRepository _detaliiComandaRepository;

        public ComenziService(IComenziRepository comenziRepository, IDetaliiComandaRepository detaliiComandaRepository)
        {
            _comenziRepository = comenziRepository;
            _detaliiComandaRepository = detaliiComandaRepository;
        }

        public string PlaseazaComanda(ComandaDTO comandaDto)
        {
            if (comandaDto == null || comandaDto.Produse == null || !comandaDto.Produse.Any())
            {
                throw new ArgumentException("Coșul este gol.");
            }

            var totalPlata = comandaDto.Produse.Sum(p => p.Pret * p.Cantitate);

            var comanda = new Comenzi
            {
                DataComanda = DateTime.Now,
                TotalPlata = totalPlata,
                ClientId = comandaDto.ClientId,
                MetodaPlataId = comandaDto.MetodaPlata
            };

            _comenziRepository.AddAsync(comanda).Wait();

            foreach (var produs in comandaDto.Produse)
            {
                var detaliiComanda = new DetaliiComanda
                {
                    ComandaId = comanda.IdComanda,
                    ProdusId = produs.IdProdus,
                    Cantitate = produs.Cantitate
                };

                _detaliiComandaRepository.AddAsync(detaliiComanda).Wait();
            }

            return "Comanda a fost plasată cu succes.";
        }

        public async Task<List<ComandaDTO>> GetOrdersByUserIdAsync(string userId)
        {
            if (int.TryParse(userId, out int clientId))
            {
                var orders = (await _comenziRepository.GetAllAsync())
                    .Where(c => c.ClientId == clientId)
                    .Select(c => new ComandaDTO
                    {
                        ClientId = c.ClientId,
                    })
                    .ToList();

                return orders;
            }
            else
            {
                return new List<ComandaDTO>();
            }
        }

        public async Task<int?> GetClientIdByUserIdAsync(string userId)
        {
            var client = await _comenziRepository.GetClientByUserIdAsync(userId);
            return client?.IdClient;
        }

        public async Task<IEnumerable<Comenzi>> GetOrdersByClientIdAsync(int clientId)
        {
            return await _comenziRepository.GetOrdersByClientIdAsync(clientId);
        }
    }
}
