using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetPay.Common;

namespace NetPay.Data.Models
{
    public class SupplierService
    {
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
