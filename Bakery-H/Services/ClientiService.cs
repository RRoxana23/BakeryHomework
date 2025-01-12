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
    public class ClientiService : IClientiService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Clienti> GetClientByUserIdAsync(Guid userId)
        {
            return await _unitOfWork.Clienti.GetByUserIdAsync(userId);
        }
    }
}
