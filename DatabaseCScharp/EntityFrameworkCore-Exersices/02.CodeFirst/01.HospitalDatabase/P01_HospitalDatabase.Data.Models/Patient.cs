using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = null!;

        [MaxLength(80)]
        [Unicode(false)]
        public string? Email { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; } = new List<Visitation>();
        public virtual ICollection<Diagnose> Diagnoses { get; set; } = new List<Diagnose>();
        public virtual ICollection<PatientMedicament> Prescriptions { get; set; } = new List<PatientMedicament>();
    }
}
