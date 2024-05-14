using Bakery_H.Models;
using Bakery_H.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bakery_H.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
