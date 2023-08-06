using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncInn.Migrations
{
    /// <inheritdoc />
    public partial class EnumAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1,
                column: "Layout",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2,
                column: "Layout",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 3,
                column: "Layout",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1,
                column: "Layout",
                value: 222);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2,
                column: "Layout",
                value: 222);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 3,
                column: "Layout",
                value: 222);
        }
    }
}
