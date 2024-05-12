using System.ComponentModel.DataAnnotations;

namespace Bakery_Homework.Models
{
    public class MetodePlata
    {
        [Key]
        public int IdMetodaPlata { get; set; }
        public bool Cash { get; set; }
        public bool Card { get; set; }
    }
}
