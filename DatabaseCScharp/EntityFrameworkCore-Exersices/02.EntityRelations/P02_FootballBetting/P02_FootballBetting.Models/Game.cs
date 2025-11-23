namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; } = null!;

        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; } = null!;

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal HomeTeamBetRate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal AwayTeamBetRate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal DrawBetRate { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public MatchOutcome Result { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
            = new HashSet<PlayerStatistic>();

        public virtual ICollection<Bet> Bets { get; set; }
            = new HashSet<Bet>();
    }
}
