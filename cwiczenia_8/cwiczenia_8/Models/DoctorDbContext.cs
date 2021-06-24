using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8.Models
{
    public class DoctorDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public DoctorDbContext()
        {

        }
        public DoctorDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>((builder) =>
            {
                builder.HasKey(e => e.IdDoctor);
                builder.Property(e => e.IdDoctor).ValueGeneratedOnAdd();

                builder.Property(e => e.FirstName).HasMaxLength(100);
                builder.Property(e => e.FirstName).IsRequired();

                builder.Property(e => e.LastName).HasMaxLength(100);
                builder.Property(e => e.LastName).IsRequired();

                builder.Property(e => e.Email).HasMaxLength(100);
                builder.Property(e => e.Email).IsRequired();


                builder.HasMany(e => e.Prescriptions).WithOne(e => e.Doctor).HasForeignKey(e => e.IdDoctor).IsRequired();
            });
            modelBuilder.Entity<Patient>((builder) =>
            {
                builder.HasKey(e => e.IdPatient);
                builder.Property(e => e.IdPatient).ValueGeneratedOnAdd();

                builder.Property(e => e.FirstName).HasMaxLength(100);
                builder.Property(e => e.FirstName).IsRequired();

                builder.Property(e => e.LastName).HasMaxLength(100);
                builder.Property(e => e.LastName).IsRequired();


                builder.HasMany(e => e.Prescriptions).WithOne(e => e.Patient).HasForeignKey(e => e.IdPatient).IsRequired();
            });
            modelBuilder.Entity<Medicament>((builder) =>
            {
                builder.HasKey(e => e.IdMedicament);
                builder.Property(e => e.IdMedicament).ValueGeneratedOnAdd();

                builder.Property(e => e.Name).HasMaxLength(100);
                builder.Property(e => e.Name).IsRequired();

                builder.Property(e => e.Description).HasMaxLength(100);
                builder.Property(e => e.Description).IsRequired();

                builder.Property(e => e.Type).HasMaxLength(100);
                builder.Property(e => e.Type).IsRequired();


                builder.HasMany(e => e.Prescription_Medicaments).WithOne(e => e.Medicament).HasForeignKey(e => e.IdMedicament).IsRequired();
            });
            modelBuilder.Entity<Prescription>((builder) =>
            {
                builder.HasKey(e => e.IdPrescription);
                builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

                builder.Property(e => e.Date).IsRequired();
                builder.Property(e => e.DueDate).IsRequired();


                builder.HasMany(e => e.Prescription_Medicaments).WithOne(e => e.Prescription).HasForeignKey(e => e.IdPrescription).IsRequired();
            });
            modelBuilder.Entity<Prescription_Medicament>((builder) =>
            {
                builder.HasKey(e => new
                {
                    e.IdMedicament,
                    e.IdPrescription
                });

                builder.Property(e => e.Details).HasMaxLength(100);
                builder.Property(e => e.Details).IsRequired();
            });

            var dictDoctors = new List<Doctor>();
            dictDoctors.Add(new Doctor { IdDoctor = 1, FirstName = "doktor1", LastName = "nazwiskodoktora1", Email = "doktor1@bla.pl" });
            dictDoctors.Add(new Doctor { IdDoctor = 2, FirstName = "doktor2", LastName = "nazwiskodoktora2", Email = "doktor2@bla.pl" });
            dictDoctors.Add(new Doctor { IdDoctor = 3, FirstName = "doktor3", LastName = "nazwiskodoktora3", Email = "doktor3@bla.pl" });
            dictDoctors.Add(new Doctor { IdDoctor = 4, FirstName = "doktor4", LastName = "nazwiskodoktora4", Email = "doktor4@bla.pl" });

            var dictPatients = new List<Patient>();
            dictPatients.Add(new Patient { IdPatient = 1, FirstName = "pacjent1", LastName = "nazwiskopacjenta1", Birthdate = DateTime.Now });
            dictPatients.Add(new Patient { IdPatient = 2, FirstName = "pacjent2", LastName = "nazwiskopacjenta2", Birthdate = DateTime.Now });
            dictPatients.Add(new Patient { IdPatient = 3, FirstName = "pacjent3", LastName = "nazwiskopacjenta3", Birthdate = DateTime.Now });
            dictPatients.Add(new Patient { IdPatient = 4, FirstName = "pacjent4", LastName = "nazwiskopacjenta4", Birthdate = DateTime.Now });

            var dictMedicaments = new List<Medicament>();
            dictMedicaments.Add(new Medicament { IdMedicament = 1, Name = "lek1", Description = "opisleku1", Type = "typ1" });
            dictMedicaments.Add(new Medicament { IdMedicament = 2, Name = "lek2", Description = "opisleku2", Type = "typ2" });
            dictMedicaments.Add(new Medicament { IdMedicament = 3, Name = "lek3", Description = "opisleku3", Type = "typ3" });
            dictMedicaments.Add(new Medicament { IdMedicament = 4, Name = "lek4", Description = "opisleku4", Type = "typ4" });

            var dictPrescriptions = new List<Prescription>();
            dictPrescriptions.Add(new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now, /*Doctor = dictDoctors[2], Patient = dictPatients[0],*/ IdDoctor = 3, IdPatient = 1 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now, /*Doctor = dictDoctors[3], Patient = dictPatients[3],*/ IdDoctor = 4, IdPatient = 4 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 3, Date = DateTime.Now, DueDate = DateTime.Now, /*Doctor = dictDoctors[1], Patient = dictPatients[2],*/ IdDoctor = 2, IdPatient = 3 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 4, Date = DateTime.Now, DueDate = DateTime.Now, /*Doctor = dictDoctors[0], Patient = dictPatients[1],*/ IdDoctor = 1, IdPatient = 2 });

            var dictPrescription_Medicaments = new List<Prescription_Medicament>();
            dictPrescription_Medicaments.Add(new Prescription_Medicament { Dose = 3, Details = "szczegoly1", /*Medicament = dictMedicaments[2], Prescription = dictPrescriptions[2],*/ IdMedicament = 3, IdPrescription = 3 });
            dictPrescription_Medicaments.Add(new Prescription_Medicament { Dose = 4, Details = "szczegoly2", /*Medicament = dictMedicaments[1], Prescription = dictPrescriptions[3],*/ IdMedicament = 2, IdPrescription = 4 });
            dictPrescription_Medicaments.Add(new Prescription_Medicament { Dose = 2, Details = "szczegoly3", /*Medicament = dictMedicaments[3], Prescription = dictPrescriptions[0],*/ IdMedicament = 4, IdPrescription = 1 });
            dictPrescription_Medicaments.Add(new Prescription_Medicament { Dose = 10, Details = "szczegoly4", /*Medicament = dictMedicaments[0], Prescription = dictPrescriptions[1],*/ IdMedicament = 1, IdPrescription = 2 });

            modelBuilder.Entity<Doctor>().HasData(dictDoctors);
            modelBuilder.Entity<Patient>().HasData(dictPatients);
            modelBuilder.Entity<Medicament>().HasData(dictMedicaments);
            modelBuilder.Entity<Prescription>().HasData(dictPrescriptions);
            modelBuilder.Entity<Prescription_Medicament>().HasData(dictPrescription_Medicaments);
        }
    }
}
