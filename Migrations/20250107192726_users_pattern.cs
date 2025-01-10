using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estudoRepository.Migrations
{
    /// <inheritdoc />
    public partial class users_pattern : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "document");

            migrationBuilder.AddColumn<string>(
                name: "userType",
                table: "Users",
                type: "TEXT",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "document",
                table: "Users",
                newName: "password");
        }
    }
}
