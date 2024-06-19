using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    [Index(nameof(Phone), IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ReadOnly(true)]
        public int Id { get; set; }
        [Required]
        [MaxLength(10), MinLength(10)]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b")]
        public string Phone { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
