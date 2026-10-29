using System.ComponentModel.DataAnnotations;

namespace ZSK_Rechner.Models
{
    public class ExchangeRate
    {
        public int Id { get; private set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; } = null!;
        [Range(0.01, 1000000, ErrorMessage = "Rate must be between 0.01 and 1000000")]
        public decimal Rate { get; set; }
        public DateTime ValidFrom { get; set; } = DateTime.UtcNow;
    }
}