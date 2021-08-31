using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilParc.Migrations
{
    public partial class EditVehiculeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Assurence_AssurenceNumero",
                table: "Vehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Chauffeur_ChauffeurId",
                table: "Vehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Maintenance_MaintenanceId",
                table: "Vehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Visite_VisiteId",
                table: "Vehicule");

            migrationBuilder.AlterColumn<int>(
                name: "VisiteId",
                table: "Vehicule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "Vehicule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChauffeurId",
                table: "Vehicule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssurenceNumero",
                table: "Vehicule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Assurence_AssurenceNumero",
                table: "Vehicule",
                column: "AssurenceNumero",
                principalTable: "Assurence",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Chauffeur_ChauffeurId",
                table: "Vehicule",
                column: "ChauffeurId",
                principalTable: "Chauffeur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Maintenance_MaintenanceId",
                table: "Vehicule",
                column: "MaintenanceId",
                principalTable: "Maintenance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Visite_VisiteId",
                table: "Vehicule",
                column: "VisiteId",
                principalTable: "Visite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Assurence_AssurenceNumero",
                table: "Vehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Chauffeur_ChauffeurId",
                table: "Vehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Maintenance_MaintenanceId",
                table: "Vehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Visite_VisiteId",
                table: "Vehicule");

            migrationBuilder.AlterColumn<int>(
                name: "VisiteId",
                table: "Vehicule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "Vehicule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ChauffeurId",
                table: "Vehicule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AssurenceNumero",
                table: "Vehicule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Assurence_AssurenceNumero",
                table: "Vehicule",
                column: "AssurenceNumero",
                principalTable: "Assurence",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Chauffeur_ChauffeurId",
                table: "Vehicule",
                column: "ChauffeurId",
                principalTable: "Chauffeur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Maintenance_MaintenanceId",
                table: "Vehicule",
                column: "MaintenanceId",
                principalTable: "Maintenance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Visite_VisiteId",
                table: "Vehicule",
                column: "VisiteId",
                principalTable: "Visite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
