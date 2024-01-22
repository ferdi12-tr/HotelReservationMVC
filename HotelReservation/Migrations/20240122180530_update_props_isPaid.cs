using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    public partial class update_props_isPaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_PaymentInfo_PaymentInfoId",
                table: "BookingInfo");

            migrationBuilder.DropTable(
                name: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_BookingInfo_PaymentInfoId",
                table: "BookingInfo");

            migrationBuilder.AddColumn<int>(
                name: "CustomerInfoId",
                table: "BookingInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "BookingInfo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "BookingInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfo_CustomerInfoId",
                table: "BookingInfo",
                column: "CustomerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_CustomerInfo_CustomerInfoId",
                table: "BookingInfo",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_CustomerInfo_CustomerInfoId",
                table: "BookingInfo");

            migrationBuilder.DropTable(
                name: "CustomerInfo");

            migrationBuilder.DropIndex(
                name: "IX_BookingInfo_CustomerInfoId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "CustomerInfoId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "BookingInfo");

            migrationBuilder.CreateTable(
                name: "PaymentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfo_PaymentInfoId",
                table: "BookingInfo",
                column: "PaymentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_PaymentInfo_PaymentInfoId",
                table: "BookingInfo",
                column: "PaymentInfoId",
                principalTable: "PaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
