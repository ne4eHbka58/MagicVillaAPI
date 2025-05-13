using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumberForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 501,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 502,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 503,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5718));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5727));
        }
    }
}
