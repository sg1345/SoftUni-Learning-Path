

namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using static Common.ApplicationConstants;
    using Models;
    public class HospitalContext : DbContext
    {
        public HospitalContext() { }

        public HospitalContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; } 
        public virtual DbSet<Medicament> Medicaments { get; set; } 
        public virtual DbSet<PatientMedicament> PatientsMedicaments { get; set; } 
        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });
        }
    }
}
