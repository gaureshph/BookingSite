using System.Threading.Tasks;
using BookingSite.Web.DbContexts;
using BookingSite.Web.DomainModels;

namespace BookingSite.Web.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingSiteDbContext _bookingSiteDbContext;
        public BookingRepository(BookingSiteDbContext bookingSiteDbContext)
        {
            _bookingSiteDbContext = bookingSiteDbContext;
        }

        public async Task<int> AddBookingAsync(HotelBooking booking)
        {
            _bookingSiteDbContext.Add(booking);
            await _bookingSiteDbContext.SaveChangesAsync();
            return booking.ID;
        }
    }
}
