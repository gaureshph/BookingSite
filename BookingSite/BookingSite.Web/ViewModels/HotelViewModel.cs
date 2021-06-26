using System.Collections.Generic;

namespace BookingSite.Web.ViewModels
{
    public class HotelViewModel
    {
        public string City { get; set; }
        public string HotelName { get; set; }
        public string HotelCode { get; set; }
        public int StarRating { get; set; }
        public List<HotelRoomViewModel> HotelRooms { get; set; }
    }
}
