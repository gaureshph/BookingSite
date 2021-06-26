using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSite.Web.Migrations
{
    public partial class DummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelMaster",
                columns: new[] { "ID", "Address", "City", "HotelCode", "HotelName", "StarRating" },
                values: new object[,]
                {
                    { 1, "abc", "Navi Mumbai", "NMHI", "Hotel Inn", 3 },
                    { 2, "xyz", "Navi Mumbai", "NMHD", "Hotel Darbar", 3 },
                    { 3, "def", "Mumbai", "MHO", "Hotel Oberoi", 5 }
                });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "ID", "HotelCode", "RoomType", "Tariff" },
                values: new object[,]
                {
                    { 1, "NMHI", "Single", 1500m },
                    { 2, "NMHI", "Double", 2500m },
                    { 3, "NMHI", "Twin", 2650m },
                    { 4, "NMHD", "Single", 1500m },
                    { 5, "NMHD", "Double", 2500m },
                    { 6, "NMHD", "Twin", 2650m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelMaster",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelMaster",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelMaster",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
