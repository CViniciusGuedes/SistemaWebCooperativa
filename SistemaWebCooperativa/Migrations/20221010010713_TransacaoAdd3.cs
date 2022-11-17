using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebCooperativa.Migrations
{
    public partial class TransacaoAdd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumo_Propriedade_propriedadeId",
                table: "Insumo");

            migrationBuilder.RenameColumn(
                name: "propriedadeId",
                table: "Insumo",
                newName: "cooperadoid");

            migrationBuilder.RenameIndex(
                name: "IX_Insumo_propriedadeId",
                table: "Insumo",
                newName: "IX_Insumo_cooperadoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumo_Cooperado_cooperadoid",
                table: "Insumo",
                column: "cooperadoid",
                principalTable: "Cooperado",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumo_Cooperado_cooperadoid",
                table: "Insumo");

            migrationBuilder.RenameColumn(
                name: "cooperadoid",
                table: "Insumo",
                newName: "propriedadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Insumo_cooperadoid",
                table: "Insumo",
                newName: "IX_Insumo_propriedadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumo_Propriedade_propriedadeId",
                table: "Insumo",
                column: "propriedadeId",
                principalTable: "Propriedade",
                principalColumn: "Id");
        }
    }
}
