




using P01_StudentSystem.Common;

namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using static Common.EntityValidation.Student;

    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Unicode(true)]
        public string Name { get; set; } = null!;

        
        [Column(TypeName = "char(10)")]
        public string? PhoneNumber { get; set; } 

        [Required]
        public DateTime RegisteredOn { get; set; } = DateTime.Now;

        public DateTime? Birthday { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
            = new HashSet<StudentCourse>();

        public virtual ICollection<Homework> Homeworks { get; set; } 
            = new HashSet<Homework>();
    }
}
