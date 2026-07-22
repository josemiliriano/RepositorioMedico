using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Correciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDPatient_Insurances_InsuranceId",
                table: "CDPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_CDPatient_Persons_PersonId",
                table: "CDPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_CDUser_Persons_PersonId",
                table: "CDUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_CDPatient_PatientId",
                table: "MedicalAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_CDPatient_PatientId",
                table: "MedicalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CDUser",
                table: "CDUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CDPatient",
                table: "CDPatient");

            migrationBuilder.RenameTable(
                name: "CDUser",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "CDPatient",
                newName: "Patients");

            migrationBuilder.RenameIndex(
                name: "IX_CDUser_PersonId",
                table: "Users",
                newName: "IX_Users_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_CDPatient_PersonId",
                table: "Patients",
                newName: "IX_Patients_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_CDPatient_InsuranceId",
                table: "Patients",
                newName: "IX_Patients_InsuranceId");

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IDUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Patients_PatientId",
                table: "MedicalAppointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Insurances_InsuranceId",
                table: "Patients",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "IdInsurance");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Persons_PersonId",
                table: "Patients",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "IdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "IdPerson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Patients_PatientId",
                table: "MedicalAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Insurances_InsuranceId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Persons_PersonId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "CDUser");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "CDPatient");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PersonId",
                table: "CDUser",
                newName: "IX_CDUser_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_PersonId",
                table: "CDPatient",
                newName: "IX_CDPatient_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_InsuranceId",
                table: "CDPatient",
                newName: "IX_CDPatient_InsuranceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CDUser",
                table: "CDUser",
                column: "IDUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CDPatient",
                table: "CDPatient",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_CDPatient_Insurances_InsuranceId",
                table: "CDPatient",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "IdInsurance");

            migrationBuilder.AddForeignKey(
                name: "FK_CDPatient_Persons_PersonId",
                table: "CDPatient",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "IdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_CDUser_Persons_PersonId",
                table: "CDUser",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "IdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_CDPatient_PatientId",
                table: "MedicalAppointments",
                column: "PatientId",
                principalTable: "CDPatient",
                principalColumn: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_CDPatient_PatientId",
                table: "MedicalHistories",
                column: "PatientId",
                principalTable: "CDPatient",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
