using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertExBackend.Migrations
{
    /// <inheritdoc />
    public partial class nominationModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentApproval",
                table: "Nominations");

            migrationBuilder.DropColumn(
                name: "LndApproval",
                table: "Nominations");

            migrationBuilder.AddColumn<bool>(
                name: "IsDepartmentApproved",
                table: "Nominations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLndApproved",
                table: "Nominations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDepartmentApproved",
                table: "Nominations");

            migrationBuilder.DropColumn(
                name: "IsLndApproved",
                table: "Nominations");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentApproval",
                table: "Nominations",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LndApproval",
                table: "Nominations",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
