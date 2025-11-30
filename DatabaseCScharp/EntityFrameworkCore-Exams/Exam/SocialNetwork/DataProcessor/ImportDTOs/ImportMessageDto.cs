using SocialNetwork.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.Common.EntityValidation.Message;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    [XmlType("Message")]
    public class ImportMessageDto
    {
        [XmlElement("Content")]
        [Required]
        [MaxLength(MaxContentLength)]
        [MinLength(MinContentLength)]
        public string Content { get; set; } = null!;

        [XmlAttribute("SentAt")]
        [Required]
        public string SentAt { get; set; } = null!;

        [XmlElement("Status")]
        [Required]
        public string Status { get; set; } = null!;

        [XmlElement("ConversationId")]
        [Required]
        public string ConversationId { get; set; } = null!;

        [XmlElement("SenderId")]
        [Required]
        public string SenderId { get; set; } = null!;
    }
}
