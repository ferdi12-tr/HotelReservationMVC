using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    public partial class room_image_amenity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasAirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    HasBalcony = table.Column<bool>(type: "bit", nullable: false),
                    HasGym = table.Column<bool>(type: "bit", nullable: false),
                    HasParking = table.Column<bool>(type: "bit", nullable: false),
                    HasBeachView = table.Column<bool>(type: "bit", nullable: false),
                    Bethroom = table.Column<int>(type: "int", nullable: false),
                    HasFreeNewspaper = table.Column<bool>(type: "bit", nullable: false),
                    HasPool = table.Column<bool>(type: "bit", nullable: false),
                    HasTv = table.Column<bool>(type: "bit", nullable: false),
                    HasRoomService = table.Column<bool>(type: "bit", nullable: false),
                    HasBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    HasFreeWifi = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerHour = table.Column<double>(type: "float", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomImageId = table.Column<int>(type: "int", nullable: false),
                    RoomAmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_RoomAmenity_RoomAmenityId",
                        column: x => x.RoomAmenityId,
                        principalTable: "RoomAmenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_RoomImage_RoomImageId",
                        column: x => x.RoomImageId,
                        principalTable: "RoomImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomAmenityId",
                table: "Room",
                column: "RoomAmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomImageId",
                table: "Room",
                column: "RoomImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomAmenity");

            migrationBuilder.DropTable(
                name: "RoomImage");
        }
    }
}
