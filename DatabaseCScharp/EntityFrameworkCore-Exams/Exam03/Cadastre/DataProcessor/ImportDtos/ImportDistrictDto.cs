using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Cadastre.Common.EntityValidation.District;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDto
    {
        [XmlAttribute("Region")]
        [Required]
        public string Region { get; set; } = null!;

        [XmlElement("Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [XmlElement("PostalCode")]
        [Required]
        [MaxLength(PostalCodeLength)]
        [MinLength(PostalCodeLength)]
        [RegularExpression(PostalCodeRegex)]
        public string PostalCode { get; set; } = null!;

        [XmlArray("Properties")]
        public ImportPropertyDto[] Properties { get; set; } = null!;
    }
}
