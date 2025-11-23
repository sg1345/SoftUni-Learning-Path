namespace MusicHub.Data.Models
{
    using static Common.EntityValidation.Producer;
    using System.ComponentModel.DataAnnotations;
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; } = null!;


        [MaxLength(PseudonymLength)]
        public string? Pseudonym { get; set; }

        [MaxLength(PhoneNumberLength)]
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
            = new HashSet<Album>();
    }
}
