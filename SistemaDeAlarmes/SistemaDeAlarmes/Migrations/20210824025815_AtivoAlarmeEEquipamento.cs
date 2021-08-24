using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeAlarmes.Migrations
{
    public partial class AtivoAlarmeEEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Equipamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Alarmes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Alarmes");
        }
    }
}
