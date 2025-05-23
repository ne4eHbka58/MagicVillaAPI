﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class FeelVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7285), "Some text about this Royal beautiful Villa", "", "Royal Villa", 5, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Pool", new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7298), "Some details about this Pool Villa", "", "Pool Villa", 4, 150.0, 450, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Access to the ocean", new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7300), "Villa with access to the ocean", "", "Ocean Villa", 2, 100.0, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Near the beach", new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7302), "Villa near the beach", "", "Beach Villa", 4, 180.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Royal pool", new DateTime(2025, 5, 13, 14, 30, 48, 898, DateTimeKind.Local).AddTicks(7304), "Royal Villa with a big pool", "", "Royal Pool Villa", 7, 260.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
