namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(256)]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(254)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
            = new HashSet<Bet>();
    }

}
