using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.Common.EntityValidation.Post;
using Newtonsoft.Json;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    public class ImportPostDto
    {
        [JsonProperty("Content")]
        [Required]
        [MaxLength(MaxContentLength)]
        [MinLength(MinContentLength)]
        public string Content { get; set; } = null!;

        [JsonProperty("CreatedAt")]
        [Required]
        public string CreatedAt { get; set; } = null!;

        [JsonProperty("CreatorId")]
        [Required]
        public int CreatorId { get; set; }
    }
}
