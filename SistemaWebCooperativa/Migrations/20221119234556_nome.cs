using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebCooperativa.Migrations
{
    public partial class nome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumo_Cooperado_cooperadoid",
                table: "Insumo");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Cooperado_cooperadoid",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "cooperadoid",
                table: "Transacoes",
                newName: "producaoid");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_cooperadoid",
                table: "Transacoes",
                newName: "IX_Transacoes_producaoid");

            migrationBuilder.AlterColumn<int>(
                name: "cooperadoid",
                table: "Insumo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insumo_Cooperado_cooperadoid",
                table: "Insumo",
                column: "cooperadoid",
                principalTable: "Cooperado",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Producao_producaoid",
                table: "Transacoes",
                column: "producaoid",
                principalTable: "Producao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumo_Cooperado_cooperadoid",
                table: "Insumo");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Producao_producaoid",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "producaoid",
                table: "Transacoes",
                newName: "cooperadoid");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_producaoid",
                table: "Transacoes",
                newName: "IX_Transacoes_cooperadoid");

            migrationBuilder.AlterColumn<int>(
                name: "cooperadoid",
                table: "Insumo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumo_Cooperado_cooperadoid",
                table: "Insumo",
                column: "cooperadoid",
                principalTable: "Cooperado",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Cooperado_cooperadoid",
                table: "Transacoes",
                column: "cooperadoid",
                principalTable: "Cooperado",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
