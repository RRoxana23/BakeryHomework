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

namespace Bakery_Homework.Services
{
    public class AngajatiService : IAngajatiService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AngajatiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Angajati>> GetAllAsync()
        {
            return await _unitOfWork.Angajati.GetAllAsync();
        }

        public async Task<Angajati> GetByIdAsync(int id)
        {
            return await _unitOfWork.Angajati.GetByIdAsync(id);
        }

        public async Task CreateAsync(Angajati angajati)
        {
            await _unitOfWork.Angajati.CreateAsync(angajati);
        }

        public async Task UpdateAsync(Angajati angajati)
        {
            await _unitOfWork.Angajati.UpdateAsync(angajati);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Angajati.DeleteAsync(id);
        }

        public bool AngajatiExists(int id)
        {
            return _unitOfWork.Angajati.AngajatiExists(id);
        }

        public IEnumerable<FormulareAngajare> GetAllFormulareAngajare()
        {
            return _unitOfWork.Angajati.GetAllFormulareAngajare();
        }

        public IEnumerable<Locatii> GetAllLocatii()
        {
            return _unitOfWork.Angajati.GetAllLocatii();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _unitOfWork.Angajati.GetAllUsers();
        }
    }
}
