using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static NetPay.Common.EntityValidation.Service;

namespace NetPay.Data.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ServiceNameMaxLength)]
        public string ServiceName { get; set; } = null!;

        public ICollection<Expense> Expenses { get; set; }
            = new HashSet<Expense>();

        public ICollection<SupplierService> SuppliersServices { get; set; }
            = new HashSet<SupplierService>();
    }
}
