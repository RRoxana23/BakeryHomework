using Bakery_H.Repositories.Interfaces;
using Bakery_H.Services.Interfaces;
using Bakery_Homework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery_H.Services
{
    public class FormulareAngajareService : IFormulareAngajareService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FormulareAngajareService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FormulareAngajare>> GetAllFormulareAsync()
        {
            return await _unitOfWork.FormulareAngajare.GetAllWithLocatiiAsync();
        }

        public async Task<FormulareAngajare> GetFormularByIdAsync(int id)
        {
            return await _unitOfWork.FormulareAngajare.GetByIdWithLocatieAsync(id);
        }

        public async Task CreateFormularAsync(FormulareAngajare formulareAngajare)
        {
            await _unitOfWork.FormulareAngajare.AddAsync(formulareAngajare);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateFormularAsync(FormulareAngajare formulareAngajare)
        {
            await _unitOfWork.FormulareAngajare.UpdateAsync(formulareAngajare);
            await _unitOfWork.SaveChangesAsync();
        }

        public void DeleteFormular(int id)
        {
            _unitOfWork.FormulareAngajare.Delete(id);
        }
    }
}
