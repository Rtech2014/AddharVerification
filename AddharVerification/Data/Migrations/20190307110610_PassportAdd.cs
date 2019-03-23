using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddharVerification.Data.Migrations
{
    public partial class PassportAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    MobileNum = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    CivilStatus = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    NameOfMother = table.Column<string>(nullable: true),
                    NameOfFather = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    ApplicationMemberId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passport_AspNetUsers_ApplicationMemberId",
                        column: x => x.ApplicationMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passport_ApplicationMemberId",
                table: "Passport",
                column: "ApplicationMemberId",
                unique: true,
                filter: "[ApplicationMemberId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passport");
        }
    }
}
