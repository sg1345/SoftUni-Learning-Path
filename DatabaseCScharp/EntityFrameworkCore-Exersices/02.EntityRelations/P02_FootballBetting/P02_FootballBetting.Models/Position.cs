namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Player> Players { get; set; }
            = new HashSet<Player>();
    }

}
