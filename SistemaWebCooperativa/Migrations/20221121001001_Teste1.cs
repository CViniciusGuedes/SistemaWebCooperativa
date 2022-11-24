using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebCooperativa.Migrations
{
    public partial class Teste1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooperado_Propriedade_propriedadeidId",
                table: "Cooperado");

            migrationBuilder.DropIndex(
                name: "IX_Cooperado_propriedadeidId",
                table: "Cooperado");

            migrationBuilder.DropColumn(
                name: "propriedadeidId",
                table: "Cooperado");

            migrationBuilder.AddColumn<int>(
                name: "propriedadeid",
                table: "Cooperado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cooperado_propriedadeid",
                table: "Cooperado",
                column: "propriedadeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooperado_Propriedade_propriedadeid",
                table: "Cooperado",
                column: "propriedadeid",
                principalTable: "Propriedade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooperado_Propriedade_propriedadeid",
                table: "Cooperado");

            migrationBuilder.DropIndex(
                name: "IX_Cooperado_propriedadeid",
                table: "Cooperado");

            migrationBuilder.DropColumn(
                name: "propriedadeid",
                table: "Cooperado");

            migrationBuilder.AddColumn<int>(
                name: "propriedadeidId",
                table: "Cooperado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cooperado_propriedadeidId",
                table: "Cooperado",
                column: "propriedadeidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooperado_Propriedade_propriedadeidId",
                table: "Cooperado",
                column: "propriedadeidId",
                principalTable: "Propriedade",
                principalColumn: "Id");
        }
    }
}
