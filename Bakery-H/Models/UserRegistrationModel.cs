using System.ComponentModel.DataAnnotations;

namespace Bakery_H.Models
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Prenume { get; set; }
        [Required(ErrorMessage = "Profile picture is required")]
        public IFormFile ProfilePicture { get; set; }
    }
}
