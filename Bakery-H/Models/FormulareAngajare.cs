using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class FormulareAngajare
    {
        [Key]
        public int IdFormular { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string? Nume { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string? Prenume { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DataNasterii { get; set; }
        [Required]
        [RegularExpression("^[0-9-]{9,11}$", ErrorMessage = "Phone number must be between 9 and 11 digits.")]
        [Display(Name = "Phone number")]
        public string? NumarTelefon { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [ForeignKey("Locatie")]
        [Required]
        [Display(Name = "Please select a city")]
        public int? LocatieId { get; set; }
        public Locatii? Locatie { get; set; }
    }
}
