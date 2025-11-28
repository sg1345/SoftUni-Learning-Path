using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicines.Common.EntityValidation.Medicine;

namespace Medicines.Data.Models
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = PriceTypeName)]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [MaxLength(ProducerMaxLength)]
        public string Producer { get; set; } = null!;

        [ForeignKey(nameof(Pharmacy))]
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; } = null!;

        public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; } 
            = new HashSet<PatientMedicine>();
    }
}
