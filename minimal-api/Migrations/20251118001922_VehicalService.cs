using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api.Migrations
{
    /// <inheritdoc />
    public partial class VehicalService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Vehicals",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Vehicals",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Vehicals",
                newName: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Vehicals",
                newName: "Ano");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vehicals",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Vehicals",
                newName: "Marca");
        }
    }
}
