using System;

namespace BookingSite.Web.ViewModels
{
    public class SearchViewModel
    {
        public string City { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfRooms { get; set; }
    }
}
