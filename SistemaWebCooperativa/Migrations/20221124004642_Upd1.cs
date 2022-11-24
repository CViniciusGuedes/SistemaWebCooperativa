using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebCooperativa.Migrations
{
    public partial class Upd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Cooperado",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "cpf",
                table: "Cooperado",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}
