using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalWalletSystem.Migrations
{
    public partial class Accountmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Accountid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalBalance = table.Column<double>(type: "float", nullable: false),
                    Registerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Accountid);
                    table.ForeignKey(
                        name: "FK_Account_Register_Registerid",
                        column: x => x.Registerid,
                        principalTable: "Register",
                        principalColumn: "RegisterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Registerid",
                table: "Account",
                column: "Registerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
