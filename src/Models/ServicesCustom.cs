using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class ServicesCustom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ServiceSupport ServicesSupport { get; set; } = null!;
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
