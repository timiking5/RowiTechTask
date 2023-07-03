using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowiTechTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 3, 14, 56, 34, 356, DateTimeKind.Local).AddTicks(1610), new DateTime(2023, 7, 17, 14, 56, 34, 356, DateTimeKind.Local).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 2, 14, 56, 34, 356, DateTimeKind.Local).AddTicks(1621), new DateTime(2023, 7, 16, 14, 56, 34, 356, DateTimeKind.Local).AddTicks(1622) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Tasks",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Duration", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 6, 30, 20, 8, 28, 211, DateTimeKind.Local).AddTicks(3839), new TimeSpan(14, 0, 0, 0, 0), new DateTime(2023, 7, 14, 20, 8, 28, 211, DateTimeKind.Local).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Duration", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 6, 29, 20, 8, 28, 211, DateTimeKind.Local).AddTicks(3855), new TimeSpan(14, 0, 0, 0, 0), new DateTime(2023, 7, 13, 20, 8, 28, 211, DateTimeKind.Local).AddTicks(3856) });
        }
    }
}
