



namespace P01_StudentSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.Resorce;
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Unicode(true)]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(UrlMaxLength)]
        public string? Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;

    }
}
