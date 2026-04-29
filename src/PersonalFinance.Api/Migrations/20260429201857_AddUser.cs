using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinance.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Goals",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Goals",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "Goals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
