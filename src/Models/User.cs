using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    [Index(nameof(Phone), IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Phone { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
