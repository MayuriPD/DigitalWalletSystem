using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalWalletSystem.Migrations
{
    public partial class Thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "LoginHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TimeStamp",
                table: "LoginHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
