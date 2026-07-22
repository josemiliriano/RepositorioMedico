using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CDPerson>()
                .HasOne(p => p.User)
                .WithOne(u => u.Person)
                .HasForeignKey<CDUser>(u => u.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDPerson>()
                .HasOne(p => p.Patient)
                .WithOne(p => p.Person)
                .HasForeignKey<CDPatient>(p => p.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDPerson>()
                .HasOne(p => p.Doctor)
                .WithOne(d => d.Person)
                .HasForeignKey<CDDoctor>(d => d.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDPatient>()
                .HasOne(p => p.Insurance)
                .WithMany(i => i.Patients)
                .HasForeignKey(p => p.InsuranceId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CDDoctor>()
                .HasOne(d => d.Specialty)
                .WithMany(s => s.Doctor)
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDMedicalAppointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.MedicalAppointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDMedicalAppointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.MedicalAppointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDMedicalAppointment>()
                .HasOne(a => a.Clinic)
                .WithMany(c => c.MedicalAppointment)
                .HasForeignKey(a => a.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDMedicalHistory>()
                .HasOne(h => h.Patient)
                .WithMany(p => p.MedicalHistories)
                .HasForeignKey(h => h.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDMedicalHistory>()
                .HasOne(h => h.Doctor)
                .WithMany(d => d.MedicalHistories)
                .HasForeignKey(h => h.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDMedicalHistory>()
                .HasOne(h => h.MedicalAppointment)
                .WithMany()
                .HasForeignKey(h => h.MedicalAppointmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CDPrescription>()
                .HasOne(p => p.MedicalHistory)
                .WithMany(h => h.Prescription)
                .HasForeignKey(p => p.MedicalHistoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<CDPerson> Persons { get; set; }

        public DbSet<CDUser> Users { get; set; }

        public DbSet<CDPatient> Patients { get; set; }

        public DbSet<CDDoctor> Doctors { get; set; }

        public DbSet<CDClinic> Clinics { get; set; }

        public DbSet<CDSpecialty> Specialties { get; set; }

        public DbSet<CDInsurance> Insurances { get; set; }

        public DbSet<CDMedicalAppointment> MedicalAppointments { get; set; }

        public DbSet<CDMedicalHistory> MedicalHistories { get; set; }

        public DbSet<CDPrescription> Prescriptions { get; set; }
    }
}
