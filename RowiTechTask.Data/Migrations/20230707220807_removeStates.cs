using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RowiTechTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeStates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 8, 1, 8, 7, 123, DateTimeKind.Local).AddTicks(9670), new DateTime(2023, 7, 22, 1, 8, 7, 123, DateTimeKind.Local).AddTicks(9671) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 7, 1, 8, 7, 123, DateTimeKind.Local).AddTicks(9678), new DateTime(2023, 7, 21, 1, 8, 7, 123, DateTimeKind.Local).AddTicks(9679) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { 3, "On Review" },
                    { 5, "Needs Rework" }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 7, 18, 32, 46, 678, DateTimeKind.Local).AddTicks(5221), new DateTime(2023, 7, 21, 18, 32, 46, 678, DateTimeKind.Local).AddTicks(5222) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 6, 18, 32, 46, 678, DateTimeKind.Local).AddTicks(5227), new DateTime(2023, 7, 20, 18, 32, 46, 678, DateTimeKind.Local).AddTicks(5228) });
        }
    }
}
