using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebCooperativa.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooperado_Propriedade_propriedadeId",
                table: "Cooperado");

            migrationBuilder.RenameColumn(
                name: "propriedadeId",
                table: "Cooperado",
                newName: "propriedadeidId");

            migrationBuilder.RenameIndex(
                name: "IX_Cooperado_propriedadeId",
                table: "Cooperado",
                newName: "IX_Cooperado_propriedadeidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooperado_Propriedade_propriedadeidId",
                table: "Cooperado",
                column: "propriedadeidId",
                principalTable: "Propriedade",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooperado_Propriedade_propriedadeidId",
                table: "Cooperado");

            migrationBuilder.RenameColumn(
                name: "propriedadeidId",
                table: "Cooperado",
                newName: "propriedadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cooperado_propriedadeidId",
                table: "Cooperado",
                newName: "IX_Cooperado_propriedadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooperado_Propriedade_propriedadeId",
                table: "Cooperado",
                column: "propriedadeId",
                principalTable: "Propriedade",
                principalColumn: "Id");
        }
    }
}
