using Microsoft.EntityFrameworkCore.Migrations;

namespace AddharVerification.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aadhar",
                table: "Passport",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aadhar",
                table: "Passport");
        }
    }
}
