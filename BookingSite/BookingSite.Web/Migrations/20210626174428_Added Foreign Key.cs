using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSite.Web.Migrations
{
    public partial class AddedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HotelCode",
                table: "HotelRooms",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HotelCode",
                table: "HotelMaster",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_HotelMaster_HotelCode",
                table: "HotelMaster",
                column: "HotelCode");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelCode",
                table: "HotelRooms",
                column: "HotelCode");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_HotelMaster_HotelCode",
                table: "HotelRooms",
                column: "HotelCode",
                principalTable: "HotelMaster",
                principalColumn: "HotelCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_HotelMaster_HotelCode",
                table: "HotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_HotelCode",
                table: "HotelRooms");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_HotelMaster_HotelCode",
                table: "HotelMaster");

            migrationBuilder.AlterColumn<string>(
                name: "HotelCode",
                table: "HotelRooms",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HotelCode",
                table: "HotelMaster",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
