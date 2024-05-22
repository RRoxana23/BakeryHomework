using Bakery_H.Repositories.Interfaces;
using Bakery_H.Services.Interfaces;
using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Services
{
    public class ProduseService : IProduseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProduseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Produse>> GetAllProduseAsync()
        {
            return await _unitOfWork.Produse.GetAll();
        }

        public async Task<Produse> GetProdusByIdAsync(int id)
        {
            return await _unitOfWork.Produse.GetById(id);
        }

        public async Task CreateProdusAsync(Produse produs)
        {
            await _unitOfWork.Produse.AddAsync(produs);
        }

        public async Task UpdateProdusAsync(Produse produs)
        {
            await _unitOfWork.Produse.UpdateAsync(produs);
        }

        public void DeleteProdus(int id)
        {
            _unitOfWork.Produse.Delete(id);
        }
    }
}
