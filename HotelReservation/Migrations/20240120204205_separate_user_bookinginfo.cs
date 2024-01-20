using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    public partial class separate_user_bookinginfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingInfo_AspNetUsers_AppUserId",
                table: "BillingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_AspNetUsers_AppUserId",
                table: "BookingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInfo_AspNetUsers_AppUserId",
                table: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInfo_AppUserId",
                table: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_BookingInfo_AppUserId",
                table: "BookingInfo");

            migrationBuilder.DropIndex(
                name: "IX_BillingInfo_AppUserId",
                table: "BillingInfo");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "PaymentInfo");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BillingInfo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOutDate",
                table: "BookingInfo",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckInDate",
                table: "BookingInfo",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BookingInfoUserRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    BookingInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingInfoUserRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingInfoUserRelation_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingInfoUserRelation_BookingInfo_BookingInfoId",
                        column: x => x.BookingInfoId,
                        principalTable: "BookingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfoUserRelation_AppUserId",
                table: "BookingInfoUserRelation",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfoUserRelation_BookingInfoId",
                table: "BookingInfoUserRelation",
                column: "BookingInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingInfoUserRelation");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CheckOutDate",
                table: "BookingInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CheckInDate",
                table: "BookingInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "BookingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "BillingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfo_AppUserId",
                table: "PaymentInfo",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfo_AppUserId",
                table: "BookingInfo",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInfo_AppUserId",
                table: "BillingInfo",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingInfo_AspNetUsers_AppUserId",
                table: "BillingInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_AspNetUsers_AppUserId",
                table: "BookingInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInfo_AspNetUsers_AppUserId",
                table: "PaymentInfo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
