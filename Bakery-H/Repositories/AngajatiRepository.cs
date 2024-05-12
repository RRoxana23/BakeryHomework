using Bakery_H.Repositories.Interfaces;
using Bakery_Homework.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery_H.Repositories
{
    public class AngajatiRepository : Repository<Angajati>, IAngajatiRepository
    {
        public AngajatiRepository(DbContext dbContext) : base(dbContext) { }
    }
}
