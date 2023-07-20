using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncInn.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomsAndAmenitiesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "streetAddress",
                table: "Hotels",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Hotels",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Hotels",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Hotels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Hotels",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Hotels",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Hotels",
                newName: "ID");

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Layout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Hotels",
                newName: "streetAddress");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Hotels",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Hotels",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Hotels",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Hotels",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Hotels",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Hotels",
                newName: "id");
        }
    }
}
