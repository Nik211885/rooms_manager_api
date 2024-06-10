using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50),MinLength(5)]
        public string User_name { get; set; } = null!;
        [Required]
        public byte[] PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "user";
        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = null!;
        [Required]
        [MaxLength(10)]
        [RegularExpression("/(0[3|5|7|8|9])+([0-9]{8})\b/g")]
        public string Phone { get; set; } = null!;
        [Required]
        [MaxLength(50),MinLength(5)]
        public string FullName { get; set; } = null!;
        [MaxLength(11),MinLength(11)]
        [RegularExpression("^\\d$")]
        public string IdNumber { get; set; } = null!;
        [MaxLength(80)]
        public string? Image { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
