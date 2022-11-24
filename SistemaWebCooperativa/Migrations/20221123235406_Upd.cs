using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebCooperativa.Migrations
{
    public partial class Upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Producao");

            migrationBuilder.RenameColumn(
                name: "preco",
                table: "Producao",
                newName: "quantidade");

            migrationBuilder.AddColumn<int>(
                name: "cooperadoid",
                table: "Producao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "produtoid",
                table: "Producao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    preco = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producao_cooperadoid",
                table: "Producao",
                column: "cooperadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Producao_produtoid",
                table: "Producao",
                column: "produtoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Producao_Cooperado_cooperadoid",
                table: "Producao",
                column: "cooperadoid",
                principalTable: "Cooperado",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producao_Produto_produtoid",
                table: "Producao",
                column: "produtoid",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producao_Cooperado_cooperadoid",
                table: "Producao");

            migrationBuilder.DropForeignKey(
                name: "FK_Producao_Produto_produtoid",
                table: "Producao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Producao_cooperadoid",
                table: "Producao");

            migrationBuilder.DropIndex(
                name: "IX_Producao_produtoid",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "cooperadoid",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "produtoid",
                table: "Producao");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "Producao",
                newName: "preco");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "Producao",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Producao",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");
        }
    }
}
