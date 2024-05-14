using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Bakery_H.Models;

namespace Bakery_Homework.Models
{
    public class Angajati
    {
        [Key]
        public int IdAngajat { get; set; }
        public string? Functie { get; set; }
        public DateTime DataAngajarii { get; set; }

        [ForeignKey("Locatie")]
        public int LocatieId { get; set; }
        public Locatii? Locatie { get; set; }

        [ForeignKey("FormularAngajare")]
        public int? FormulareAngajareId { get; set; }
        public FormulareAngajare? FormularAngajare { get; set; }

        [ForeignKey("Comenzi")]
        public int? ComandaId { get; set; }
        public Comenzi? Comanda { get; set; }

        [ForeignKey("User")]
        public Guid userId { get; set; }
        public virtual User User { get; set; }
    }
}
