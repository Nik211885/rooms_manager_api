using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace src.Models
{
    [Index(nameof(Phone), IsUnique = true)]
    public class RegristCustomer
    {
        [Required]
        [MaxLength(11), MinLength(11)]
        [RegularExpression("^[0-9]*$")]
        public string IdNumber { get; set; } = null!;
        [Required]
        [MaxLength(10), MinLength(10)]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b")]
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        [Required]
        [MaxLength(50), MinLength(5)]
        public string FullName { get; set; } = null!;
    }
}
