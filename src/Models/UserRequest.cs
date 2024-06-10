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
        public string Address { get; set; } = null!;
        [Required]
        [MaxLength(10)]
        [RegularExpression("/(0[3|5|7|8|9])+([0-9]{8})\b/g")]
        public string Phone { get; set; } = null!;
        [Required]
        [MaxLength(50), MinLength(5)]
        public string FullName { get; set; } = null!;
        [MaxLength(11), MinLength(11)]
        [RegularExpression("^\\d$")]
        public string IdNumber { get; set; } = null!;
    }
}
