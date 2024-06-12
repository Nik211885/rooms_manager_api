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
        public string UserName { get; set; } = null!;
        [Required]
        public byte[] PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
        [Required]
        public IEnumerable<ServicesBases> ServicesBases { get; set; } = null!;

        [Required]
        public IEnumerable<ServicesCustom> ServicesCustoms { get; set; } = null!;
    }
}
