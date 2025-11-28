using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicines.Common.EntityValidation.Medicine;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicineDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Price")]
        [Required]
        public string Price { get; set; } = null!;

        [XmlAttribute("category")]
        [Required]
        public string Category { get; set; } = null!;

        [XmlElement("ProductionDate")]
        [Required]
        public string ProductionDate { get; set; } = null!;

        [XmlElement("ExpiryDate")]
        [Required]
        public string ExpiryDate { get; set; } = null!;

        [XmlElement("Producer")]
        [Required]
        [MaxLength(ProducerMaxLength)]
        [MinLength(ProducerMinLength)]
        public string Producer { get; set; } = null!;
    }
}
