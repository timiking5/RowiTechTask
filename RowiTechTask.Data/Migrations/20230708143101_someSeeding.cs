using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RowiTechTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class someSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TagTask",
                columns: new[] { "TagId", "TaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagName" },
                values: new object[] { 5, "Real Job" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 8, 17, 31, 1, 131, DateTimeKind.Local).AddTicks(8075), new DateTime(2023, 7, 22, 17, 31, 1, 131, DateTimeKind.Local).AddTicks(8076) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 7, 17, 31, 1, 131, DateTimeKind.Local).AddTicks(8082), new DateTime(2023, 7, 21, 17, 31, 1, 131, DateTimeKind.Local).AddTicks(8083) });

            migrationBuilder.InsertData(
                table: "TagTask",
                columns: new[] { "TagId", "TaskId" },
                values: new object[] { 5, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TagTask",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TagTask",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TagTask",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "TagTask",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 8, 17, 28, 10, 727, DateTimeKind.Local).AddTicks(679), new DateTime(2023, 7, 22, 17, 28, 10, 727, DateTimeKind.Local).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 7, 17, 28, 10, 727, DateTimeKind.Local).AddTicks(687), new DateTime(2023, 7, 21, 17, 28, 10, 727, DateTimeKind.Local).AddTicks(688) });
        }
    }
}
