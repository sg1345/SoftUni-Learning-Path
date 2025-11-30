using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.Common.EntityValidation.Post;

namespace SocialNetwork.Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxContentLength)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }

        public virtual User Creator { get; set; } = null!;
    }
}
