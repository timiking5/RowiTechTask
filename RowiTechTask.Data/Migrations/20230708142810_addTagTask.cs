using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowiTechTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTagTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagTask_Tags_TagsId",
                table: "TagTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TagTask_Tasks_TasksId",
                table: "TagTask");

            migrationBuilder.RenameColumn(
                name: "TasksId",
                table: "TagTask",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "TagTask",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TagTask_TasksId",
                table: "TagTask",
                newName: "IX_TagTask_TagId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TagTask_Tags_TagId",
                table: "TagTask",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagTask_Tasks_TaskId",
                table: "TagTask",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagTask_Tags_TagId",
                table: "TagTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TagTask_Tasks_TaskId",
                table: "TagTask");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "TagTask",
                newName: "TasksId");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "TagTask",
                newName: "TagsId");

            migrationBuilder.RenameIndex(
                name: "IX_TagTask_TagId",
                table: "TagTask",
                newName: "IX_TagTask_TasksId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TagTask_Tags_TagsId",
                table: "TagTask",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagTask_Tasks_TasksId",
                table: "TagTask",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
