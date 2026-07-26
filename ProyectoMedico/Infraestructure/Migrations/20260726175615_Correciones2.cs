using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Correciones2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicalHistoryId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "CDMedicalHistoryIdMedicalHistory",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_CDMedicalHistoryIdMedicalHistory",
                table: "Prescriptions",
                column: "CDMedicalHistoryIdMedicalHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_MedicalHistories_CDMedicalHistoryIdMedicalHistory",
                table: "Prescriptions",
                column: "CDMedicalHistoryIdMedicalHistory",
                principalTable: "MedicalHistories",
                principalColumn: "IdMedicalHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_MedicalHistories_CDMedicalHistoryIdMedicalHistory",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_CDMedicalHistoryIdMedicalHistory",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "CDMedicalHistoryIdMedicalHistory",
                table: "Prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicalHistoryId",
                table: "Prescriptions",
                column: "MedicalHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                table: "Prescriptions",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "IdMedicalHistory");
        }
    }
}
