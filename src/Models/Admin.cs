using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ReadOnly(true)]
        public int Id { get; set; }
        public User User { get; set; } = null!;
        [Required]
        [MaxLength(80)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Information { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = null!;
        [Required]
        [MaxLength(50), MinLength(5)]
        public string FullName { get; set; } = null!;
        [Required]
        [MaxLength(11), MinLength(11)]
        [RegularExpression("^[0-9]*$")]
        public string IdNumber { get; set; } = null!;
        [Required]
        [MaxLength(80)]
        public string Image { get; set; } = null!;
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }

        public IEnumerable<Room>? Rooms { get; set; }
        public IEnumerable<Contract>? Contracts { get; set; }
        public IEnumerable<Message>? Message { get; set; }
        public IEnumerable<Notify>? Notify { get; set; }
        public IEnumerable<Bill>? Bills { get; set; }
        public IEnumerable<ServiceSupport>? ServicesSupport { get; set; }
    }
}
