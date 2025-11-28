using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Cadastre.Common.EntityValidation.Property;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class ImportPropertyDto
    {
        [XmlElement("PropertyIdentifier")]
        [Required]
        [MaxLength(PropertyIdentifierMaxLength)]
        [MinLength(PropertyIdentifierMinLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [XmlElement("Area")]
        [Required]
        public string Area { get; set; } = null!;

        [XmlElement("Details")]
        [MaxLength(DetailsMaxLength)]
        [MinLength(DetailsMinLength)]
        public string? Details { get; set; }

        [XmlElement("Address")]
        [Required]
        [MaxLength(AddressMaxLength)]
        [MinLength(AddressMinLength)]
        public string Address { get; set; } = null!;

        [XmlElement("DateOfAcquisition")]
        [Required]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
