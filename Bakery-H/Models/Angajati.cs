using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class Angajati
    {
        [Key]
        public int IdAngajat { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Functie { get; set; }
        public DateTime DataAngajarii { get; set; }
        public string? NumarTelefon { get; set; }

        [ForeignKey("Locatie")]
        public int LocatieId { get; set; }
        public Locatii? Locatie { get; set; }

        [ForeignKey("FormularAngajare")]
        public int? FormulareAngajareId { get; set; }
        public FormulareAngajare? FormularAngajare { get; set; }

        public int? ComandaId { get; set; }
        public Comenzi? Comanda { get; set; }
    }
}
