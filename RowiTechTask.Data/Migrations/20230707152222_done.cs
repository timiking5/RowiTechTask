using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowiTechTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class done : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RemarkId",
                table: "Solutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 7, 18, 22, 22, 806, DateTimeKind.Local).AddTicks(1944), new DateTime(2023, 7, 21, 18, 22, 22, 806, DateTimeKind.Local).AddTicks(1945) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 6, 18, 22, 22, 806, DateTimeKind.Local).AddTicks(1950), new DateTime(2023, 7, 20, 18, 22, 22, 806, DateTimeKind.Local).AddTicks(1951) });

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_RemarkId",
                table: "Solutions",
                column: "RemarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Remarks_RemarkId",
                table: "Solutions",
                column: "RemarkId",
                principalTable: "Remarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Remarks_RemarkId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_RemarkId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "RemarkId",
                table: "Solutions");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 7, 18, 20, 39, 402, DateTimeKind.Local).AddTicks(6082), new DateTime(2023, 7, 21, 18, 20, 39, 402, DateTimeKind.Local).AddTicks(6083) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 7, 6, 18, 20, 39, 402, DateTimeKind.Local).AddTicks(6088), new DateTime(2023, 7, 20, 18, 20, 39, 402, DateTimeKind.Local).AddTicks(6089) });
        }
    }
}
