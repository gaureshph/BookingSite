using System.Threading.Tasks;
using BookingSite.Web.DbContexts;
using System.Collections.Generic;
using BookingSite.Web.DomainModels;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<HotelBooking>> GetBookingsAsync()
        {
            return await _bookingSiteDbContext.HotelBookings.ToListAsync();
        }
    }
}
