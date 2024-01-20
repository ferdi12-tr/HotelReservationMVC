using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    public partial class update_fkid_prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingInfo_AspNetUsers_AppUserId",
                table: "BillingInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PaymentInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BillingInfo");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "BillingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingInfo_AspNetUsers_AppUserId",
                table: "BillingInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingInfo_AspNetUsers_AppUserId",
                table: "BillingInfo");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "BillingInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BillingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingInfo_AspNetUsers_AppUserId",
                table: "BillingInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
