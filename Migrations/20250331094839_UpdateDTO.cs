using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ubuntu_health_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PracticeName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PracticePhone",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PracticeName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PracticePhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "AspNetUsers");
        }
    }
}
