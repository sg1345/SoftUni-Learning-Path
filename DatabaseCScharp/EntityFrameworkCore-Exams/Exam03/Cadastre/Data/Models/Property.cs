using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Cadastre.Common.EntityValidation.Property;

namespace Cadastre.Data.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        public int Area { get; set; }

        [MaxLength(DetailsMaxLength)]
        public string Details { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public DateTime DateOfAcquisition { get; set; }

        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }
        public virtual District District { get; set; } = null!;

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = 
            new HashSet<PropertyCitizen>();
    }
}
