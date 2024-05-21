using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class FormulareAngajare
    {
        [Key]
        public int IdFormular { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public string? NumarTelefon { get; set; }
        public string? Email { get; set; }

        [ForeignKey("Locatie")]
        public int LocatieId { get; set; }
        public Locatii? Locatie { get; set; }
    }
}
