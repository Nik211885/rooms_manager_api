using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace src.Models
{
    [Index(nameof(Phone), IsUnique = true)]
    public class UserRequest
    {
        [Required]
        [MaxLength(10), MinLength(10)]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b")]
        public string Phone { get; set; } = null!;
        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        public string Password { get; set; } = null!;
    }
}
