using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BookingSite.Web.DbContexts;
using BookingSite.Web.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSite.Web.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly BookingSiteDbContext _bookingSiteDbContext;
        public MasterRepository(BookingSiteDbContext bookingSiteDbContext)
        {
            _bookingSiteDbContext = bookingSiteDbContext;
        }

        public async Task<List<City>> GetCitiesAsync()
        {
            var uniqueCities = await _bookingSiteDbContext.HotelMaster.Select(hotel => hotel.City).Distinct().ToListAsync();
            return uniqueCities.Select(city => new City { Name = city }).ToList();
        }

        public async Task<Hotel> GetHotelByHotelRoomAsync(int hotelRoomId)
        {
            var hotelRoom = await _bookingSiteDbContext.HotelRooms.FindAsync(hotelRoomId);
            return await _bookingSiteDbContext.HotelMaster.FirstOrDefaultAsync(hotel => hotel.HotelCode == hotelRoom.HotelCode);
        }

        public async Task<HotelRoom> GetHotelRoomAsync(int hotelRoomId)
        {
            return await _bookingSiteDbContext.HotelRooms.FindAsync(hotelRoomId);
        }

        public async Task<List<Hotel>> GetHotelsAsync(string city)
        {
            var hotels = _bookingSiteDbContext.HotelMaster.AsQueryable();
            if (!string.IsNullOrWhiteSpace(city))
            {
                hotels = hotels.Where(hotel => hotel.City == city);
            }
            return await hotels.Include(hotel => hotel.Rooms).ToListAsync();
        }

        public List<NoOfRoomsOption> GetNoOfRoomsOptions()
        {
            return new List<NoOfRoomsOption>
            {
                new NoOfRoomsOption{ Option = 1 },
                new NoOfRoomsOption{ Option = 2 },
                new NoOfRoomsOption{ Option = 3 },
                new NoOfRoomsOption{ Option = 4 },
                new NoOfRoomsOption{ Option = 5 },
                new NoOfRoomsOption{ Option = 6 }
            };
        }
    }
}
