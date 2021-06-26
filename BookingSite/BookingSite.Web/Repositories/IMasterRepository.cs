using System.Threading.Tasks;
using System.Collections.Generic;
using BookingSite.Web.DomainModels;

namespace BookingSite.Web.Repositories
{
    public interface IMasterRepository
    {
        Task<List<Hotel>> GetHotelsAsync(string city);
        Task<List<HotelRoom>> GetHotelRoomsAsync(string hotelCode);
        Task<Hotel> GetHotelByHotelRoomAsync(int hotelRoomId);
        Task<List<City>> GetCitiesAsync();
        List<NoOfRoomsOption> GetNoOfRoomsOptions();
        Task<HotelRoom> GetHotelRoomAsync(int hotelRoomId);
    }
}