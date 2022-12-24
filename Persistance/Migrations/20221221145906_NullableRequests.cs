using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NullableRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 21, 16, 59, 5, 552, DateTimeKind.Local).AddTicks(4775), new DateTime(2022, 12, 21, 16, 59, 5, 552, DateTimeKind.Local).AddTicks(4656), new DateTime(2022, 12, 21, 16, 59, 5, 552, DateTimeKind.Local).AddTicks(4786) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "35578730-f502-40cb-aefc-4c9640982cef", new DateTime(2022, 12, 21, 16, 59, 5, 85, DateTimeKind.Local).AddTicks(9275), "AQAAAAIAAYagAAAAEJMgmZ0L0NnjCloTU7uwa4O4y8l7p7mIS15B8k/Qy/bGzWin3PHE/HcKa1KAc7bNvg==", new DateTime(2022, 12, 21, 16, 59, 5, 85, DateTimeKind.Local).AddTicks(9383) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "153ab15a-6c39-4109-b088-0cb9c114edb0", new DateTime(2022, 12, 21, 16, 59, 5, 85, DateTimeKind.Local).AddTicks(9408), "AQAAAAIAAYagAAAAEP0b8y9Pwy1iDq5AfCCQes10RzmYWcpvJ9YOYwn/KwUvXitAPlv6RKJ1A7TmASg8PA==", new DateTime(2022, 12, 21, 16, 59, 5, 85, DateTimeKind.Local).AddTicks(9445) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 20, 15, 25, 31, 164, DateTimeKind.Local).AddTicks(8601), new DateTime(2022, 12, 20, 15, 25, 31, 164, DateTimeKind.Local).AddTicks(8500), new DateTime(2022, 12, 20, 15, 25, 31, 164, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "59ed67a1-0518-4b11-8d9c-0fc4532d8de2", new DateTime(2022, 12, 20, 15, 25, 30, 900, DateTimeKind.Local).AddTicks(8996), "AQAAAAIAAYagAAAAENuO/ryc3vYqEieLmAZlRcOfspE7vZ5klZ8efIoKMxlRAM354C35sb9xF8tIZhyTtQ==", new DateTime(2022, 12, 20, 15, 25, 30, 900, DateTimeKind.Local).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "08b54689-ccae-4c33-9ba7-d25d75b5ab5d", new DateTime(2022, 12, 20, 15, 25, 30, 900, DateTimeKind.Local).AddTicks(9071), "AQAAAAIAAYagAAAAEOiy413Z8Au3wGd5dUumoTPuJoeoSdHKVWzEKnEYPyM3cA/qgmrfext7WJN1rygFGA==", new DateTime(2022, 12, 20, 15, 25, 30, 900, DateTimeKind.Local).AddTicks(9077) });
        }
    }
}
