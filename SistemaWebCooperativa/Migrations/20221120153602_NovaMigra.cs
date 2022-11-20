using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebCooperativa.Migrations
{
    public partial class NovaMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumo_Cooperado_cooperadoid",
                table: "Insumo");

            migrationBuilder.DropIndex(
                name: "IX_Insumo_cooperadoid",
                table: "Insumo");

            migrationBuilder.DropColumn(
                name: "cooperadoid",
                table: "Insumo");

            migrationBuilder.CreateTable(
                name: "TipoInsumo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInsumo", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoInsumo");

            migrationBuilder.AddColumn<int>(
                name: "cooperadoid",
                table: "Insumo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Insumo_cooperadoid",
                table: "Insumo",
                column: "cooperadoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumo_Cooperado_cooperadoid",
                table: "Insumo",
                column: "cooperadoid",
                principalTable: "Cooperado",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
