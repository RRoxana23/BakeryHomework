using Bakery_H.Repositories.Interfaces;
using Bakery_H.Services.Interfaces;
using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Services
{
    public class LocatiiService : ILocatiiService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocatiiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Locatii>> GetAllLocatiiAsync()
        {
            return await _unitOfWork.Locatii.GetAll();
        }

        public async Task<Locatii> GetLocatieByIdAsync(int id)
        {
            return await _unitOfWork.Locatii.GetById(id);
        }

        public async Task CreateLocatieAsync(Locatii locatie)
        {
            await _unitOfWork.Locatii.AddAsync(locatie);
        }

        public async Task UpdateLocatieAsync(Locatii locatie)
        {
            await _unitOfWork.Locatii.UpdateAsync(locatie);
        }

        public async Task DeleteLocatieAsync(int id)
        {
            await _unitOfWork.Locatii.DeleteAsync(id);
        }
    }
}
