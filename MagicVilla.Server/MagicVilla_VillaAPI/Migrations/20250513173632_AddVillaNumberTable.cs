﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "VillaNo", "CreatedDate", "SpecialDetails", "UpdatedDate" },
                values: new object[,]
                {
                    { 501, new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5853), "Room with facilities for the disabled", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 502, new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5855), "Big room", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 503, new DateTime(2025, 5, 13, 20, 36, 31, 181, DateTimeKind.Local).AddTicks(5856), "Big bath", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7304));
        }
    }
}
