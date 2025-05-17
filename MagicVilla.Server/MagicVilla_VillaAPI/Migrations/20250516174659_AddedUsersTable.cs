using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 501,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 20, 46, 58, 346, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 502,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 20, 46, 58, 346, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 503,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 20, 46, 58, 346, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 20, 46, 58, 346, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 20, 46, 58, 346, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 20, 46, 58, 346, DateTimeKind.Local).AddTicks(1176));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 20, 46, 58, 346, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 20, 46, 58, 346, DateTimeKind.Local).AddTicks(1180));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 501,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 502,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 503,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 13, 21, 37, 42, 7, DateTimeKind.Local).AddTicks(2206));

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
    }
}
