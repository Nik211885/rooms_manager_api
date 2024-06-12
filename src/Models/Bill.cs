using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DatePaid { get; set; }
        public bool IsPaid { get; set; }
        [Required]
        public IEnumerable<ServicesBases> ServicesBases { get; set; } = null!;

        [Required]
        public IEnumerable<ServicesCustom> ServicesCustoms { get; set; } = null!;
    }
}
