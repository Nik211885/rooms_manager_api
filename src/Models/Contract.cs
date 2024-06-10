﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    [Index(nameof(Customer))]
    [Index(nameof(Room))]
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Date_Hire { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string ImageContract { get; set; } = null!;
        [Required]
        public Customer Customer { get; set; } = null!;
        [Required]
        public Room Room { get; set; } = null!; 
    }
}
