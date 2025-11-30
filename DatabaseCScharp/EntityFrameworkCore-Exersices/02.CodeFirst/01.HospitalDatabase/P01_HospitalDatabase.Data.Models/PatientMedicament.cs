using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        [ForeignKey(nameof(Medicament))]
        public int MedicamentId { get; set; }
        public virtual Medicament Medicament { get; set; } = null!;
    }
}
