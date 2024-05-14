using Bakery_H.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Bakery_H.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(User user, string password);
        Task<SignInResult> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<User> GetByEmailAsync(string email);
    }
}
