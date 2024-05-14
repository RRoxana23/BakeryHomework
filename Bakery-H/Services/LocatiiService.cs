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

        public async Task<IEnumerable<Locatii>> GetAllLocatii()
        {
            return await _unitOfWork.Locatii.GetAll();
        }

        public async Task<Locatii> GetLocatieById(int id)
        {
            return await _unitOfWork.Locatii.GetById(id);
        }

        public void CreateLocatie(Locatii locatie)
        {
            _unitOfWork.Locatii.Add(locatie);
        }

        public void UpdateLocatie(Locatii locatie)
        {
            _unitOfWork.Locatii.Update(locatie);
        }

        public void DeleteLocatie(Locatii locatie)
        {
            _unitOfWork.Locatii.Delete(locatie);
        }
    }
}
