using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ImageRoom { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = null!;
        [Required]
        [DataType("decimal(16,3)")]
        public decimal PriceRoom { get; set; }
        [Required]
        public bool Hired { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameRoom { get; set; } = null!;
    }
}
