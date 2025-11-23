



namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.Homework;
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [MaxLength(ContentMaxLength)]
        public string? Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }
        
        [Required]
        public DateTime SubmissionTime { get; set; }
        
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;

    }
}
