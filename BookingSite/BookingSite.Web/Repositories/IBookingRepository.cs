using System.Threading.Tasks;
using BookingSite.Web.DomainModels;

namespace BookingSite.Web.Repositories
{
    public interface IBookingRepository
    {
        Task<int> AddBookingAsync(HotelBooking booking);
    }
}
