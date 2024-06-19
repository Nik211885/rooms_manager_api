using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ReadOnly(true)]
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReceiveId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Content { get; set; } = null!;
        [Required]
        public DateTime TimeSpan { get; set; }
    }
}
