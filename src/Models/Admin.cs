using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    [Index(nameof(User))]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User User { get; set; } = null!;
        [Required]
        [MaxLength(80)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Information { get; set; } = null!;
        public IEnumerable<Room>? Rooms { get; set; }
        public IEnumerable<Contract>? Contracts { get; set; }
        public IEnumerable<Message>? Message { get; set; }
        public IEnumerable<Notify>? Notify { get; set; }
        public IEnumerable<Bill>? Bills { get; set; }
    }
}
