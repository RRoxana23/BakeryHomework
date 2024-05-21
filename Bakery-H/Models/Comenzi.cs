using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class Comenzi
    {
        [Key]
        public int IdComanda { get; set; }
        public DateTime? DataComanda { get; set; }
        public decimal TotalPlata { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Clienti? Client { get; set; }

        [ForeignKey("MetodaPlata")]
        public int MetodaPlataId { get; set; }
        public MetodePlata? MetodaPlata { get; set; }
    }
}
