using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class Clienti
    {
        [Key]
        public int IdClient { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string? Email { get; set; }
        public string? NumarTelefon { get; set; }
    }
}
