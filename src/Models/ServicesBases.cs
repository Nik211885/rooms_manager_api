using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class ServicesBases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ReadOnly(true)]
        public int Id { get; set; }
        [Required]
        public int Counter { get; set; }
        public ServiceSupport ServiceSupport { get; set; } = null!;
        [Required]
        public DateTime Date { get; set; }
    }
}
