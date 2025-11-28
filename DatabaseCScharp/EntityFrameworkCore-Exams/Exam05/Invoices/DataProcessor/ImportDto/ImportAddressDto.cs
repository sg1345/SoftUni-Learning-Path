using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Invoices.Common.EntityValidation.Address;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressDto
    {
        [XmlElement("StreetName")]
        [Required]
        [MaxLength(StreetNameMaxLength)]
        [MinLength(StreetNameMinLength)]
        public string StreetName { get; set; } = null!;

        [XmlElement("StreetNumber")]
        [Required]
        public string StreetNumber { get; set; } = null!;

        [XmlElement("PostCode")]
        [Required]
        public string PostCode { get; set; } = null!;

        [XmlElement("City")]
        [Required]
        [MaxLength(CityMaxLength)]
        [MinLength(CityMinLength)]
        public string City { get; set; } = null!;

        [XmlElement("Country")]
        [Required]
        [MaxLength(CountryMaxLength)]
        [MinLength(CountryMinLength)]
        public string Country { get; set; } = null!;
    }
}
