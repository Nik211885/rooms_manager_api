using System.ComponentModel.DataAnnotations;

namespace src.Models
{
    public class ServicesShared
    {
        [Required]
        public string NameServices { get; set; } = null!;
        [Required]
        public decimal PriceServices { get; set; }
    }
}
