using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    public partial class rmv_appuser_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_CustomerInfo_CustomerInfoId",
                table: "BookingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_AspNetUsers_AppUserId",
                table: "CustomerInfo");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInfo_AppUserId",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "PaymentInfoId",
                table: "BookingInfo");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CustomerInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerInfoId",
                table: "BookingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_CustomerInfo_CustomerInfoId",
                table: "BookingInfo",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_CustomerInfo_CustomerInfoId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CustomerInfo");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "CustomerInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerInfoId",
                table: "BookingInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PaymentInfoId",
                table: "BookingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfo_AppUserId",
                table: "CustomerInfo",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_CustomerInfo_CustomerInfoId",
                table: "BookingInfo",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfo_AspNetUsers_AppUserId",
                table: "CustomerInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
