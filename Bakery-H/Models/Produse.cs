using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class Produse
    {
        [Key]
        public int IdProdus { get; set; }
        public string? Nume { get; set; }
        public string? Descriere { get; set; }
        public string? Ingrediente { get; set; }
        public decimal Pret { get; set; }
        public int Cantitate { get; set; }
    }
}
