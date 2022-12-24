using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SupportRequestTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DueDate", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 20, 15, 25, 31, 164, DateTimeKind.Local).AddTicks(8601), new DateTime(2022, 12, 20, 15, 25, 31, 164, DateTimeKind.Local).AddTicks(8500), 2, new DateTime(2022, 12, 20, 15, 25, 31, 164, DateTimeKind.Local).AddTicks(8607) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DueDate", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 19, 21, 3, 26, 786, DateTimeKind.Local).AddTicks(9867), new DateTime(2022, 12, 21, 21, 3, 26, 786, DateTimeKind.Local).AddTicks(9758), 1, new DateTime(2022, 12, 19, 21, 3, 26, 786, DateTimeKind.Local).AddTicks(9874) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "d518f27e-0e31-4bfc-834c-b0a709ccc979", new DateTime(2022, 12, 19, 21, 3, 26, 512, DateTimeKind.Local).AddTicks(2523), "AQAAAAIAAYagAAAAEGFxlSe4pDZQrBmkFGiw0wV8E74Rrv6+2BH8sCYfCNU5Ww8DoCflGrt0AN6ytCcopA==", new DateTime(2022, 12, 19, 21, 3, 26, 512, DateTimeKind.Local).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "0eff53b3-9c8d-4e1d-9c58-86d540f32256", new DateTime(2022, 12, 19, 21, 3, 26, 512, DateTimeKind.Local).AddTicks(2625), "AQAAAAIAAYagAAAAEGGRIVFgJi/6MEae/3X6qOWx5csU3vOGjI+OeF7HQNs9NlzqknPPc5M+yMkoScMphg==", new DateTime(2022, 12, 19, 21, 3, 26, 512, DateTimeKind.Local).AddTicks(2652) });
        }
    }
}
