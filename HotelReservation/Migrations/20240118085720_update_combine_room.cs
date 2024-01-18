using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    public partial class update_combine_room : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomAmenity_RoomAmenityId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomImage_RoomImageId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "RoomAmenity");

            migrationBuilder.DropTable(
                name: "RoomImage");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomAmenityId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomImageId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomAmenityId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "RoomImageId",
                table: "Room",
                newName: "Bethroom");

            migrationBuilder.AddColumn<bool>(
                name: "HasAirConditioning",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasBalcony",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasBeachView",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasBreakfast",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFreeNewspaper",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFreeWifi",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasGym",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasParking",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPool",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRoomService",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTv",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl1",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl2",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl3",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl4",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl5",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAirConditioning",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasBalcony",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasBeachView",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasBreakfast",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasFreeNewspaper",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasFreeWifi",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasGym",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasParking",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasPool",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasRoomService",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HasTv",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ImgUrl1",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ImgUrl2",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ImgUrl3",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ImgUrl4",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ImgUrl5",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "Bethroom",
                table: "Room",
                newName: "RoomImageId");

            migrationBuilder.AddColumn<int>(
                name: "RoomAmenityId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bethroom = table.Column<int>(type: "int", nullable: false),
                    HasAirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    HasBalcony = table.Column<bool>(type: "bit", nullable: false),
                    HasBeachView = table.Column<bool>(type: "bit", nullable: false),
                    HasBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    HasFreeNewspaper = table.Column<bool>(type: "bit", nullable: false),
                    HasFreeWifi = table.Column<bool>(type: "bit", nullable: false),
                    HasGym = table.Column<bool>(type: "bit", nullable: false),
                    HasParking = table.Column<bool>(type: "bit", nullable: false),
                    HasPool = table.Column<bool>(type: "bit", nullable: false),
                    HasRoomService = table.Column<bool>(type: "bit", nullable: false),
                    HasTv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomAmenityId",
                table: "Room",
                column: "RoomAmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomImageId",
                table: "Room",
                column: "RoomImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomAmenity_RoomAmenityId",
                table: "Room",
                column: "RoomAmenityId",
                principalTable: "RoomAmenity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomImage_RoomImageId",
                table: "Room",
                column: "RoomImageId",
                principalTable: "RoomImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
