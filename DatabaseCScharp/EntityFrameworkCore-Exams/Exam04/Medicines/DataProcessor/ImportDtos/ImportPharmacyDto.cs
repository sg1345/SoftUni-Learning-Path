using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Medicines.Common.EntityValidation.Pharmacy;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set; } = null!;

        [XmlElement("Name")]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [XmlElement("PhoneNumber")]
        [Required]
        [MaxLength(PhoneNumberLength)]
        [MinLength(PhoneNumberLength)]
        [RegularExpression(PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Medicines")]
        public ImportMedicineDto[] Medicines { get; set; } = null!;
    }
}
