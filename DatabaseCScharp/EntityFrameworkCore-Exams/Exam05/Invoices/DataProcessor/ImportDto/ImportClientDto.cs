using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Invoices.Common.EntityValidation.Client;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [XmlElement("NumberVat")]
        [Required]
        [MaxLength(NumberVatMaxLength)]
        [MinLength(NumberVatMinLength)]
        public string NumberVat { get; set; } = null!;

        [XmlArray("Addresses")]
        public ImportAddressDto[]? Addresses { get; set; }
    }
}
