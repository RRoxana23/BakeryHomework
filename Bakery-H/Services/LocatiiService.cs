using Bakery_H.Repositories.Interfaces;
using Bakery_H.Services.Interfaces;
using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Services
{
    public class LocatiiService : ILocatiiService
    {
        private readonly ILocatiiRepository _locatiiRepository;

        public LocatiiService(ILocatiiRepository locatiiRepository)
        {
            _locatiiRepository = locatiiRepository;
        }

        public async Task<IEnumerable<Locatii>> GetAllLocatii()
        {
            return await _locatiiRepository.GetAll();
        }

        public async Task<Locatii> GetLocatieById(int id)
        {
            return await _locatiiRepository.GetById(id);
        }

        public async Task CreateLocatie(Locatii locatie)
        {
            await _locatiiRepository.Add(locatie);
        }

        public async Task UpdateLocatie(Locatii locatie)
        {
            await _locatiiRepository.Update(locatie);
        }

        public async Task DeleteLocatie(int id)
        {
            await _locatiiRepository.Delete(id);
        }
    }
}
