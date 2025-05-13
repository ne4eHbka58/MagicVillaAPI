using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumberForeignKey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 501,
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(2202), 5 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 502,
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(2204), 5 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 503,
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(2206), 5 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(1949));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 501,
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2025, 5, 13, 21, 28, 25, 856, DateTimeKind.Local).AddTicks(1526), 0 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 502,
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2025, 5, 13, 21, 28, 25, 856, DateTimeKind.Local).AddTicks(1528), 0 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 503,
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2025, 5, 13, 21, 28, 25, 856, DateTimeKind.Local).AddTicks(1530), 0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 28, 25, 856, DateTimeKind.Local).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 28, 25, 856, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 28, 25, 856, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 28, 25, 856, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 28, 25, 856, DateTimeKind.Local).AddTicks(1386));
        }
    }
}
