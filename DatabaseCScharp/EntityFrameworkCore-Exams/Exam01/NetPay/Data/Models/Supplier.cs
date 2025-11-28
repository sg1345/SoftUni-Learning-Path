using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static NetPay.Common.EntityValidation.Supplier;

namespace NetPay.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SupplierNameMaxLength)]
        public string SupplierName { get; set; } = null!;

        public ICollection<SupplierService> SuppliersServices { get; set; }
            = new HashSet<SupplierService>();
    }
}
