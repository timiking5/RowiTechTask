using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowiTechTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class someNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "RoleId" },
                values: new object[] { 1, "tima310103@gmail.com", "Timofey", "Purits", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
