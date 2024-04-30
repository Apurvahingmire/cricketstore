using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CricketStore.Migrations
{
    public partial class ChangedRoleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Role",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "");
        }
    }
}
