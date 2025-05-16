using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ubuntu_health_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGenderField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Patients",
                newName: "Sex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Patients",
                newName: "Gender");
        }
    }
}
