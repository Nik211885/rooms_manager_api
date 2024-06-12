using System.ComponentModel.DataAnnotations;

namespace src.Models
{
    public class UserRequest
    {
        [Required]
        [MaxLength(50), MinLength(5)]
        public string UserName { get; set; } = null!;
        [Required]
        [RegularExpression("/^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\\W)(?!.* ).{6,16}$/")]
        public string Password { get; set; } = null!;
        [Required]
        public string Role { get; set; } = null!;
    }
}
