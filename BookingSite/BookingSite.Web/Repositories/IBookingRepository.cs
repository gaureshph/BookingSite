using System.Threading.Tasks;
using System.Collections.Generic;
using BookingSite.Web.DomainModels;

namespace BookingSite.Web.Repositories
{
    public interface IBookingRepository
    {
        Task<int> AddBookingAsync(HotelBooking booking);
        Task<List<HotelBooking>> GetBookingsAsync();
    }
}
