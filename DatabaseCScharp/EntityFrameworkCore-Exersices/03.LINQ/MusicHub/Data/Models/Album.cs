namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.Album;
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public decimal Price => Songs.Sum(s => s.Price);

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }

        public virtual Producer? Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
            = new HashSet<Song>();
    }
}
