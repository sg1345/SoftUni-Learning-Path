using SocialNetwork.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.Common.EntityValidation.User;

namespace SocialNetwork.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxUsernameLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(MaxEmailLength)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public virtual ICollection<UserConversation> UsersConversations { get; set; } = new HashSet<UserConversation>();

        public virtual ICollection<Friendship> FriendshipOne { get; set; } = new HashSet<Friendship>();
        public virtual ICollection<Friendship> FriendshipTwo { get; set; } = new HashSet<Friendship>();
    }

}
