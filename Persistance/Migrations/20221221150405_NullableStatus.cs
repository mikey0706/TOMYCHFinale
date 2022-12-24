using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NullableStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusDetails",
                table: "SupportRequests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "IssueSubject",
                table: "SupportRequests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusDetails",
                table: "SupportRequests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueSubject",
                table: "SupportRequests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
