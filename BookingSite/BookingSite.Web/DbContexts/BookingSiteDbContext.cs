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
            base.OnModelCreating(modelBuilder);
        }
    }
}