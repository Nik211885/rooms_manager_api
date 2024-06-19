using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class ServiceSupport
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ReadOnly(true)]
        public int Id { get; set; }
        [Required]
        public string NameServices { get; set; } = null!;
        [Required]
        [DataType("decimal(16,3)")]
        public decimal PriceServices { get; set; }
        [Required]
        public bool IsShared { get; set; }
        [Required]
        public DateTime DateProvide { get; set; }
        [Required]
        public bool Deleted { get; set; }

    }
}
