using System.Collections.Generic;

namespace BookingSite.Web.DomainModels
{
    public class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<HotelRoom>();
        }
        public int ID { get; set; }
        public string City { get; set; }
        public string HotelName { get; set; }
        public int StarRating { get; set; }
        public string HotelCode { get; set; }
        public string Address { get; set; }
        public ICollection<HotelRoom> Rooms { get; set; }
    }
}
