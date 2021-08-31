using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilParc.Migrations
{
    public partial class InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Chauffeur");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Chauffeur",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Chauffeur");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Chauffeur",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
