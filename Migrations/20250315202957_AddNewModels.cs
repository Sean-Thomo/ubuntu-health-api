using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediSyncApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "Invoices",
                newName: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "LicenceNumber",
                table: "Practitioners",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IssueDate",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Patients_PatientId",
                table: "Invoices",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Patients_PatientId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LicenceNumber",
                table: "Practitioners");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Invoices",
                newName: "InvoiceDate");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Invoices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
