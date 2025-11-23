

namespace P01_StudentSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.Course;
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Unicode(true)]
        public string Name { get; set; } = null!;

        [Unicode(true)]
        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Column(TypeName = PriceColumnType)]
        public decimal Price { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } 
            = new HashSet<StudentCourse>();
        public virtual ICollection<Homework> Homeworks { get; set; } 
            = new HashSet<Homework>();
        public virtual ICollection<Resource> Resources { get; set; } 
            = new HashSet<Resource>();
    }
}
