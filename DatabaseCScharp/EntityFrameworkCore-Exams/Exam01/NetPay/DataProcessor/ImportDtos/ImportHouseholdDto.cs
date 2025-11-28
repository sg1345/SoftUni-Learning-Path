using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static NetPay.Common.EntityValidation.Household;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class ImportHouseholdDto
    {
        [Required]
        [XmlAttribute("phone")]
        [MaxLength(PhoneNumberLength)]
        [MinLength(PhoneNumberLength)]
        [RegularExpression(PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlElement("ContactPerson")]
        [MinLength(ContactPersonMinLength)]
        [MaxLength(ContactPersonMaxLength)]
        public string ContactPerson { get; set; } = null!;

        
        [XmlElement("Email")]
        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        public string? Email { get; set; }

    }
}
