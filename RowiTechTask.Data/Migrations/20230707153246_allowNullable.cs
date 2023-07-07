using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowiTechTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class allowNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Remarks_RemarkId",
                table: "Solutions");

            migrationBuilder.AlterColumn<int>(
                name: "RemarkId",
                table: "Solutions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Remarks_RemarkId",
                table: "Solutions",
                column: "RemarkId",
                principalTable: "Remarks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Remarks_RemarkId",
                table: "Solutions");

            migrationBuilder.AlterColumn<int>(
                name: "RemarkId",
                table: "Solutions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Remarks_RemarkId",
                table: "Solutions",
                column: "RemarkId",
                principalTable: "Remarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
