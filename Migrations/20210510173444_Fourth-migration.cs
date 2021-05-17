using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalWalletSystem.Migrations
{
    public partial class Fourthmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "LoginHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistory_RegisterId",
                table: "LoginHistory",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginHistory_Register_RegisterId",
                table: "LoginHistory",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "RegisterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginHistory_Register_RegisterId",
                table: "LoginHistory");

            migrationBuilder.DropIndex(
                name: "IX_LoginHistory_RegisterId",
                table: "LoginHistory");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "LoginHistory");
        }
    }
}
