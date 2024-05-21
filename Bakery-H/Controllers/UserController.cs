using Bakery_H.Models;
using Bakery_H.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Bakery_Homework.Models;
using Microsoft.Extensions.Logging;

namespace Bakery_H.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, UserManager<User> userManager, ILogger<UserController> logger)
        {
            _userService = userService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Nume = model.Nume,
                    Prenume = model.Prenume
                };

                if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.ProfilePicture.CopyToAsync(memoryStream);
                        user.ProfileImage = memoryStream.ToArray();
                    }
                }

                var result = await _userService.RegisterAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Client"); 
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(model.Email, model.Password);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Welcome back!";
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    user.ProfileImage = memoryStream.ToArray();
                    await _userManager.UpdateAsync(user);
                }
            }

            return RedirectToAction("Profile");
        }

        public async Task<IActionResult> ProfilePicture(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null || user.ProfileImage == null)
            {
                return NotFound();
            }

            return File(user.ProfileImage, "image/jpeg");
        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Employees()
        {
            return View();
        }
    }
}
