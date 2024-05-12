using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class Locatii
    {
        [Key]
        public int IdLocatie { get; set; }
        public string? Nume { get; set; }
        public string? Adresa { get; set; }
        public string? NumarTelefon { get; set; }
    }
}
