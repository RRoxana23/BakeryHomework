using Bakery_H.Models;
using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Bakery_Homework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Bakery_H.Repositories;
using Bakery_Homework.DTOs;

namespace Bakery_Homework.Services
{
    public class CosService : ICosService
    {
        private readonly ICosRepository _cosRepository;
        private readonly IComenziRepository _comenziRepository;
        private readonly IDetaliiComandaRepository _detaliiComandaRepository;

        public CosService(ICosRepository cosRepository, IComenziRepository comenziRepository, IDetaliiComandaRepository detaliiComandaRepository)
        {
            _cosRepository = cosRepository;
            _comenziRepository = comenziRepository;
            _detaliiComandaRepository = detaliiComandaRepository;
        }

        public List<ProdusInCos> GetCartItems(string cartData)
        {
            return _cosRepository.GetCartItems(cartData);
        }

        public string AddToCart(string cartData, ProdusInCos produs)
        {
            var cartItems = GetCartItems(cartData);
            var existingItem = cartItems.FirstOrDefault(p => p.IdProdus == produs.IdProdus);

            if (existingItem != null)
            {
                existingItem.Cantitate += produs.Cantitate;
            }
            else
            {
                cartItems.Add(produs);
            }

            return _cosRepository.SaveCartItems(cartItems);
        }

        public string UpdateQuantity(string cartData, ProdusInCos produs)
        {
            var cartItems = GetCartItems(cartData);
            var existingItem = cartItems.FirstOrDefault(p => p.IdProdus == produs.IdProdus);

            if (existingItem != null)
            {
                existingItem.Cantitate = produs.Cantitate;
            }

            return _cosRepository.SaveCartItems(cartItems);
        }

        public string RemoveFromCart(string cartData, int idProdus)
        {
            var cartItems = GetCartItems(cartData);
            var itemToRemove = cartItems.FirstOrDefault(p => p.IdProdus == idProdus);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }

            return _cosRepository.SaveCartItems(cartItems);
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

        public string ClearCart()
        {
            return _cosRepository.SaveCartItems(new List<ProdusInCos>());
        }
    }
}
