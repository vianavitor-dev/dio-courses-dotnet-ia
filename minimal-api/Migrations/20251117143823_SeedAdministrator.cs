using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdministrator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "Administrators",
                newName: "AccountType");

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "AccountType", "Email", "Password" },
                values: new object[] { 1, "Adm", "admin@test.com", "123456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Administrators",
                newName: "Perfil");
        }
    }
}
