using System.ComponentModel.DataAnnotations;

namespace src.Models
{
    public class UserRequest
    {
        [Required]
        [RegularExpression("([\\+84|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{7})\\b")]
        public string Phone { get; set; } = null!;
        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        public string Password { get; set; } = null!;
    }
}
