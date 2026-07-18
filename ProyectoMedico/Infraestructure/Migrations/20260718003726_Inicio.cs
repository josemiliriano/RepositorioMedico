using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    IdClinic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.IdClinic);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    IdInsurance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoveragePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.IdInsurance);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    IdSpecialty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.IdSpecialty);
                });

            migrationBuilder.CreateTable(
                name: "CDPatient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChronicDiseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDPatient", x => x.IdPatient);
                    table.ForeignKey(
                        name: "FK_CDPatient_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "IdInsurance");
                    table.ForeignKey(
                        name: "FK_CDPatient_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "CDUser",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDay = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDUser", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_CDUser_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    MedicalLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsExperience = table.Column<int>(type: "int", nullable: false),
                    ConsultationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.IdDoctor);
                    table.ForeignKey(
                        name: "FK_Doctors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FK_Doctors_Specialties_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialties",
                        principalColumn: "IdSpecialty");
                });

            migrationBuilder.CreateTable(
                name: "MedicalAppointments",
                columns: table => new
                {
                    IdMedicalAppointment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAppointments", x => x.IdMedicalAppointment);
                    table.ForeignKey(
                        name: "FK_MedicalAppointments_CDPatient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "CDPatient",
                        principalColumn: "IdPatient");
                    table.ForeignKey(
                        name: "FK_MedicalAppointments_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "IdClinic");
                    table.ForeignKey(
                        name: "FK_MedicalAppointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor");
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    IdMedicalHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    MedicalAppointmentId = table.Column<int>(type: "int", nullable: true),
                    ConsultationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.IdMedicalHistory);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_CDPatient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "CDPatient",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_MedicalHistories_MedicalAppointments_MedicalAppointmentId",
                        column: x => x.MedicalAppointmentId,
                        principalTable: "MedicalAppointments",
                        principalColumn: "IdMedicalAppointment");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalHistoryId = table.Column<int>(type: "int", nullable: false),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "IdMedicalHistory");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CDPatient_InsuranceId",
                table: "CDPatient",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_CDPatient_PersonId",
                table: "CDPatient",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CDUser_PersonId",
                table: "CDUser",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityId",
                table: "Doctors",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointments_ClinicId",
                table: "MedicalAppointments",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointments_DoctorId",
                table: "MedicalAppointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointments_PatientId",
                table: "MedicalAppointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_DoctorId",
                table: "MedicalHistories",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_MedicalAppointmentId",
                table: "MedicalHistories",
                column: "MedicalAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicalHistoryId",
                table: "Prescriptions",
                column: "MedicalHistoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDUser");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "MedicalAppointments");

            migrationBuilder.DropTable(
                name: "CDPatient");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
