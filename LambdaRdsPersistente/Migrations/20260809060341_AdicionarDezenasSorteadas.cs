using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LambdaRdsPersistente.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDezenasSorteadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numeros",
                table: "Concursos",
                newName: "DezenasSorteadasOrdemSorteio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DezenasSorteadasOrdemSorteio",
                table: "Concursos",
                newName: "Numeros");
        }
    }
}
