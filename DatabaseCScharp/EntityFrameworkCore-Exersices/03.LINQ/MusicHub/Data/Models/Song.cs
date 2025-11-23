namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using MusicHub.Data.Models.Enums;
    using static Common.EntityValidation.Song;
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; }

        [Required]
        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; }

        [Required]
        [Column(TypeName = "decimal(13,4)")]
        public decimal Price {  get; set; }

        public virtual Album? Album { get; set; }
        public virtual Writer Writer { get; set; } = null!;

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
            = new HashSet<SongPerformer>();
    }
}
