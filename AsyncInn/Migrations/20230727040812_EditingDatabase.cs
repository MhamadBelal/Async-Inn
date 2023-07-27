using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncInn.Migrations
{
    /// <inheritdoc />
    public partial class EditingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_AmenityID",
                table: "RoomAmenities");

            migrationBuilder.DropColumn(
                name: "AmenitiesID",
                table: "RoomAmenities");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomAmenities",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_RoomId",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_RoomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                columns: new[] { "AmenityID", "RoomID" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "RoomAmenities",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesID",
                table: "RoomAmenities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                columns: new[] { "AmenitiesID", "RoomId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityID",
                table: "RoomAmenities",
                column: "AmenityID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
