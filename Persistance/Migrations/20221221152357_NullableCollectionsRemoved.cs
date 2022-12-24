using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NullableCollectionsRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 21, 17, 23, 56, 601, DateTimeKind.Local).AddTicks(1080), new DateTime(2022, 12, 21, 17, 23, 56, 601, DateTimeKind.Local).AddTicks(987), new DateTime(2022, 12, 21, 17, 23, 56, 601, DateTimeKind.Local).AddTicks(1087) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "711c984c-b37b-49b9-ad47-f7456bff8cd6", new DateTime(2022, 12, 21, 17, 23, 56, 316, DateTimeKind.Local).AddTicks(8356), "AQAAAAIAAYagAAAAEGGc1uHrkM4AGS9UBjkGzvBe0gn2EuIZa980asX/Tx3YQt715UZmddLfyMcTXiA1WA==", new DateTime(2022, 12, 21, 17, 23, 56, 316, DateTimeKind.Local).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "a78820d0-3d19-40dc-b1e0-b3e8adfa5318", new DateTime(2022, 12, 21, 17, 23, 56, 316, DateTimeKind.Local).AddTicks(8439), "AQAAAAIAAYagAAAAELj6P4lWV4m4KTdMr3dmg+CKHN5UiqyQwHCLlgyaY2zJVuYuNAF+x7l3x5izsmZF7g==", new DateTime(2022, 12, 21, 17, 23, 56, 316, DateTimeKind.Local).AddTicks(8444) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 21, 17, 4, 4, 932, DateTimeKind.Local).AddTicks(4163), new DateTime(2022, 12, 21, 17, 4, 4, 932, DateTimeKind.Local).AddTicks(4069), new DateTime(2022, 12, 21, 17, 4, 4, 932, DateTimeKind.Local).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "3f590fb0-ec75-413e-aa23-7c7a52a464c7", new DateTime(2022, 12, 21, 17, 4, 4, 670, DateTimeKind.Local).AddTicks(2554), "AQAAAAIAAYagAAAAEHI6caOBCPWJPhgaM2zpE5cVDJthp1X/3WqaPoh1GK9Si8V28vzHS0TNXoJFssokPA==", new DateTime(2022, 12, 21, 17, 4, 4, 670, DateTimeKind.Local).AddTicks(2625) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { "da07b5f4-61fc-4e7f-9c6f-421cb827ac1e", new DateTime(2022, 12, 21, 17, 4, 4, 670, DateTimeKind.Local).AddTicks(2638), "AQAAAAIAAYagAAAAEGt8Lp/fDOWRjfECUS2pQRojIKvpnRdC0eok47YSppUlHlRDDLmQMgMIYmE+xKHZrA==", new DateTime(2022, 12, 21, 17, 4, 4, 670, DateTimeKind.Local).AddTicks(2644) });
        }
    }
}
