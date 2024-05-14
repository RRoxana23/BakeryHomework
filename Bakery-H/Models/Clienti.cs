using Bakery_H.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakery_Homework.Models
{
    public class Clienti
    {
        [Key]
        public int IdClient { get; set; }
        public string? Adresa { get; set; }
        public string? Email { get; set; }

        [ForeignKey("User")]
        public Guid userId { get; set; }
        public virtual User User { get; set; }
    }
}
