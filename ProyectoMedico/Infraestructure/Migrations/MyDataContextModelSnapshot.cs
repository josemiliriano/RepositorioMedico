using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(MyDataContext))]
    partial class MyDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CDClinic", b =>
                {
                    b.Property<int>("IdClinic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClinic"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClinic");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("Domain.Entities.CDDoctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<decimal>("ConsultationFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("date");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("MedicalLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessionalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("int");

                    b.Property<int>("YearsExperience")
                        .HasColumnType("int");

                    b.HasKey("IdDoctor");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("SpecialityId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Domain.Entities.CDInsurance", b =>
                {
                    b.Property<int>("IdInsurance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInsurance"));

                    b.Property<decimal>("CoveragePercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CoverageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<string>("InsuranceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInsurance");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("Domain.Entities.CDMedicalAppointment", b =>
                {
                    b.Property<int>("IdMedicalAppointment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicalAppointment"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("date");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedicalAppointment");

                    b.HasIndex("ClinicId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalAppointments");
                });

            modelBuilder.Entity("Domain.Entities.CDMedicalHistory", b =>
                {
                    b.Property<int>("IdMedicalHistory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicalHistory"));

                    b.Property<DateTime>("ConsultationDate")
                        .HasColumnType("date");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("MedicalAppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("MedicalNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedicalHistory");

                    b.HasIndex("DoctorId");

                    b.HasIndex("MedicalAppointmentId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalHistories");
                });

            modelBuilder.Entity("Domain.Entities.CDPatient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<string>("Allergies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChronicDiseases")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("date");

                    b.HasKey("IdPatient");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("CDPatient");
                });

            modelBuilder.Entity("Domain.Entities.CDPerson", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerson"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPerson");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Domain.Entities.CDPrescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("MedicalHistoryId")
                        .HasColumnType("int");

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PrescriptionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPrescription");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Domain.Entities.CDSpecialty", b =>
                {
                    b.Property<int>("IdSpecialty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSpecialty"));

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSpecialty");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("Domain.Entities.CDUser", b =>
                {
                    b.Property<int>("IDUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUser"));

                    b.Property<DateTime>("CreationDay")
                        .HasColumnType("date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("IDUser");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("CDUser");
                });

            modelBuilder.Entity("Domain.Entities.CDDoctor", b =>
                {
                    b.HasOne("Domain.Entities.CDPerson", "Person")
                        .WithOne("Doctor")
                        .HasForeignKey("Domain.Entities.CDDoctor", "PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CDSpecialty", "Specialty")
                        .WithMany("Doctor")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Domain.Entities.CDMedicalAppointment", b =>
                {
                    b.HasOne("Domain.Entities.CDClinic", "Clinic")
                        .WithMany("MedicalAppointment")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CDDoctor", "Doctor")
                        .WithMany("MedicalAppointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CDPatient", "Patient")
                        .WithMany("MedicalAppointment")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.CDMedicalHistory", b =>
                {
                    b.HasOne("Domain.Entities.CDDoctor", "Doctor")
                        .WithMany("MedicalHistories")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CDMedicalAppointment", "MedicalAppointment")
                        .WithMany()
                        .HasForeignKey("MedicalAppointmentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Entities.CDPatient", "Patient")
                        .WithMany("MedicalHistorhy")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("MedicalAppointment");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.CDPatient", b =>
                {
                    b.HasOne("Domain.Entities.CDInsurance", "Insurance")
                        .WithMany("Patient")
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CDPerson", "Person")
                        .WithOne("Patient")
                        .HasForeignKey("Domain.Entities.CDPatient", "PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Insurance");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.CDPrescription", b =>
                {
                    b.HasOne("Domain.Entities.CDMedicalHistory", "MedicalHistory")
                        .WithMany("Prescription")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("Domain.Entities.CDUser", b =>
                {
                    b.HasOne("Domain.Entities.CDPerson", "Person")
                        .WithOne("User")
                        .HasForeignKey("Domain.Entities.CDUser", "PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.CDClinic", b =>
                {
                    b.Navigation("MedicalAppointment");
                });

            modelBuilder.Entity("Domain.Entities.CDDoctor", b =>
                {
                    b.Navigation("MedicalAppointments");

                    b.Navigation("MedicalHistories");
                });

            modelBuilder.Entity("Domain.Entities.CDInsurance", b =>
                {
                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.CDMedicalHistory", b =>
                {
                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Domain.Entities.CDPatient", b =>
                {
                    b.Navigation("MedicalAppointment");

                    b.Navigation("MedicalHistorhy");
                });

            modelBuilder.Entity("Domain.Entities.CDPerson", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.CDSpecialty", b =>
                {
                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
