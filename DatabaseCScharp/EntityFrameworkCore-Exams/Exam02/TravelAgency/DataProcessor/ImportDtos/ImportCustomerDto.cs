using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static TravelAgency.Common.EntityValidation.Customer;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlElement("FullName")]
        [Required]
        [MaxLength(FullNameMaxLength)]
        [MinLength(FullNameMinLength)]
        public string FullName { get; set; } = null!;

        [XmlElement("Email")]
        [Required]
        [MaxLength(EmailMaxLength)]
        [MinLength(EmailMinLength)]
        public string Email { get; set; } = null!;

        [XmlAttribute("phoneNumber")]
        [Required]
        [RegularExpression(PhoneNumberRegex)]
        [MaxLength(PhoneNumberLength)]
        [MinLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;
    }
}
