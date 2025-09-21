using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityBreaks.Web1.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoDeleteAtNoProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Property",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Property",
                keyColumn: "id_property",
                keyValue: 1,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Property",
                keyColumn: "id_property",
                keyValue: 2,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Property",
                keyColumn: "id_property",
                keyValue: 3,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Property",
                keyColumn: "id_property",
                keyValue: 4,
                column: "DeletedAt",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Property");
        }
    }
}
