using BookingSite.Web.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSite.Web.DbContexts
{
    public class BookingSiteDbContext : DbContext
    {
        public BookingSiteDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Hotel> HotelMaster { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 1, Address = "abc", City = "Navi Mumbai", HotelCode = "NMHI", HotelName = "Hotel Inn", StarRating = 3 });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 2, Address = "xyz", City = "Navi Mumbai", HotelCode = "NMHD", HotelName = "Hotel Darbar", StarRating = 3 });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 3, Address = "def", City = "Mumbai", HotelCode = "MHO", HotelName = "Hotel Oberoi", StarRating = 5 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { ID = 1, RoomType = "Single", HotelCode = "NMHI", Tariff = 1500 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { ID = 2, RoomType = "Double", HotelCode = "NMHI", Tariff = 2500 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { ID = 3, RoomType = "Twin", HotelCode = "NMHI", Tariff = 2650 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { ID = 4, RoomType = "Single", HotelCode = "NMHD", Tariff = 1500 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { ID = 5, RoomType = "Double", HotelCode = "NMHD", Tariff = 2500 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { ID = 6, RoomType = "Twin", HotelCode = "NMHD", Tariff = 2650 });
            modelBuilder.Entity<HotelRoom>()
                .HasOne(room => room.Hotel)
                .WithMany(hotel => hotel.Rooms)
                .HasForeignKey(room => room.HotelCode)
                .HasPrincipalKey(hotel => hotel.HotelCode);
            base.OnModelCreating(modelBuilder);
        }
    }
}