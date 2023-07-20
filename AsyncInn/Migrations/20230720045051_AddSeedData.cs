using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsyncInn.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "ID");

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Blue Amenity" },
                    { 2, "Red Amenity" },
                    { 3, "Green Amenity" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Country", "Name", "Phone", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Amman", "Jordan", "Blue Hotel", "0791420372", "Middle East", "University Street" },
                    { 2, "Amman", "Jordan", "Red Hotel", "0791420372", "Middle East", "University Street" },
                    { 3, "Amman", "Jordan", "Green Hotel", "0791420372", "Middle East", "University Street" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 222, "Blue Room" },
                    { 2, 222, "Red Room" },
                    { 3, 222, "Green Room" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Rooms",
                newName: "Id");
        }
    }
}
