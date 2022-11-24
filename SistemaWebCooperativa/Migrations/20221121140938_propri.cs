using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebCooperativa.Migrations
{
    public partial class propri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoInsumo");

            migrationBuilder.AlterColumn<int>(
                name: "uf",
                table: "Propriedade",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "uf",
                table: "Propriedade",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
