using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class ExportSoldProductDto
    {
        [Required]
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [Required]
        [XmlArray("soldProducts")]
        public SoldProductDetailsDto[] SoldProducts { get; set; } = null!;
    }
}
