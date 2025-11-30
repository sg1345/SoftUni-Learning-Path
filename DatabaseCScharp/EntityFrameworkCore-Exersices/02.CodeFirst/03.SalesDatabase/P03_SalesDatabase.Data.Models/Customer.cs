using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(80)]
        [Unicode(false)]
        public string Email { get; set; } = null!;

        [Required]
        public string CreditCardNumber { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
