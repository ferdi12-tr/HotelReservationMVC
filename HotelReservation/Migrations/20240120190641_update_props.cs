using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    public partial class update_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_AspNetUsers_AppUserId",
                table: "BookingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_Room_RoomId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "BookedRoomId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "BookedUser",
                table: "BookingInfo");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "BookingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "BookingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_AspNetUsers_AppUserId",
                table: "BookingInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_Room_RoomId",
                table: "BookingInfo",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_AspNetUsers_AppUserId",
                table: "BookingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_Room_RoomId",
                table: "BookingInfo");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "BookingInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "BookingInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookedRoomId",
                table: "BookingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookedUser",
                table: "BookingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_AspNetUsers_AppUserId",
                table: "BookingInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_Room_RoomId",
                table: "BookingInfo",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
