namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Team> PrimaryKitTeams { get; set; }
            = new HashSet<Team>();
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
            = new HashSet<Team>();
    }
}
