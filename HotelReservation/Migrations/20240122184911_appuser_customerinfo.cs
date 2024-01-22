using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    public partial class appuser_customerinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "CustomerInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfo_AppUserId",
                table: "CustomerInfo",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfo_AspNetUsers_AppUserId",
                table: "CustomerInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_AspNetUsers_AppUserId",
                table: "CustomerInfo");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInfo_AppUserId",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CustomerInfo");
        }
    }
}
