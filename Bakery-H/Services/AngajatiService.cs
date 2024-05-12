using Bakery_H.Repositories.Interfaces;
using Bakery_H.Services.Interfaces;

namespace Bakery_H.Services
{
    public class AngajatiService: IAngajatiService
    {
        private readonly IUnitOfWork _unitOfWork;
    }
}
