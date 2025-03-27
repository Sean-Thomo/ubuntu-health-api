using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ubuntu_health_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrescriptionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "MedicationName",
                table: "Prescriptions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "Prescriptions",
                newName: "Frequency");

            migrationBuilder.AlterColumn<string>(
                name: "Instructions",
                table: "Prescriptions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Prescriptions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Refills",
                table: "Prescriptions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PrescriptionMedication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Dosage = table.Column<string>(type: "TEXT", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedication_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedication_PrescriptionId",
                table: "PrescriptionMedication",
                column: "PrescriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedication");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Refills",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Prescriptions",
                newName: "MedicationName");

            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "Prescriptions",
                newName: "ExpiryDate");

            migrationBuilder.AlterColumn<string>(
                name: "Instructions",
                table: "Prescriptions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Prescriptions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
