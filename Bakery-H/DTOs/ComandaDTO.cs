namespace Bakery_Homework.DTOs
{
    public class ComandaDTO
    {
        public int ClientId { get; set; }
        public int MetodaPlata { get; set; }
        public List<ProdusDTO> Produse { get; set; }
        public decimal TotalPlata { get; set; }
        public DateTime DataComanda { get; set; }
    }
}
