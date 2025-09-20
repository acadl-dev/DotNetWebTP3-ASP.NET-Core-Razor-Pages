using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityBreaks.Web1.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Property",
                newName: "id_property");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "id_country");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "City",
                newName: "id_city");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Property",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id_country", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { 1, "BR", "Brasil" },
                    { 2, "AR", "Argentina" },
                    { 3, "FR", "França" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "id_city", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "João Pessoa" },
                    { 2, 1, "Fortaleza" },
                    { 3, 3, "Lion" },
                    { 4, 3, "Bordéus" }
                });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "id_property", "CityId", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 1, 1, "Santa Grelha", 210.20m },
                    { 2, 2, "Moleska Gastrobar", 230.90m },
                    { 3, 3, "Bouchon Fiston", 300.00m },
                    { 4, 3, "Les Pavès de Saint Jean", 390.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "id_city",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id_country",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "id_property",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "id_property",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "id_property",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "id_property",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "id_city",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "id_city",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "id_city",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id_country",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id_country",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "id_property",
                table: "Property",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_country",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_city",
                table: "City",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
