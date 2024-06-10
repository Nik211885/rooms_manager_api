using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    [Index(nameof(User))]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Contract Contract { get; set; } = null!;
        [Required]
        public bool Deleted { get; set; }
        public IEnumerable<Message>? Message { get; set; }
        public IEnumerable<Bill>? Bills { get; set; }
    }
}
