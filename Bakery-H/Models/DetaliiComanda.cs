using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class DetaliiComanda
    {
        [Key]
        public int IdDetaliiComanda { get; set; }

        [ForeignKey("Produs")]
        public int ProdusId { get; set; }
        public Produse? Produs { get; set; }

        [ForeignKey("Comanda")]
        public int ComandaId { get; set; }
        public Comenzi? Comanda { get; set; }

        public int Cantitate { get; set; }
    }
}

