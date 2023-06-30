using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RowiTechTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Amount", "CreatedDate", "Duration", "ExpirationDate", "LongDescription", "PayTypeId", "ShortDescription", "StateId", "UserId" },
                values: new object[,]
                {
                    { 1, 2000m, new DateTime(2023, 6, 30, 20, 8, 28, 211, DateTimeKind.Local).AddTicks(3839), new TimeSpan(14, 0, 0, 0, 0), new DateTime(2023, 7, 14, 20, 8, 28, 211, DateTimeKind.Local).AddTicks(3852), "We need to build a marketplace with admins, users, logging. Users must be able to complete tasks and get rewarded for them", 1, "Marketplace with tasks", 1, null },
                    { 2, 5000m, new DateTime(2023, 6, 29, 20, 8, 28, 211, DateTimeKind.Local).AddTicks(3855), new TimeSpan(14, 0, 0, 0, 0), new DateTime(2023, 7, 13, 20, 8, 28, 211, DateTimeKind.Local).AddTicks(3856), "My room is a mess! I need somebody to clean it up, because i won't handle it myself... You will get paid tho", 2, "I need you to clean my room", 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
