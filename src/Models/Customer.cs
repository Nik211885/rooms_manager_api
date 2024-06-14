using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User User { get; set; } = null!;
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        [MaxLength(50), MinLength(5)]
        public string FullName { get; set; } = null!;
        [Required]
        [MaxLength(11), MinLength(11)]
        [RegularExpression("^[0-9]*$")]
        public string IdNumber { get; set; } = null!;
        [MaxLength(80)]
        public string? Image { get; set; }
        public Nullable<bool> Gender { get; set; } 
        public Nullable<DateTime> BirthDay { get; set; } 

        public IEnumerable<Message>? Message { get; set; }
        public IEnumerable<Bill>? Bills { get; set; }
        public IEnumerable<ServicesBases>? ServicesBases { get; set; }
        public IEnumerable<ServicesCustom>? ServicesCustoms { get; set; }
    }
}
