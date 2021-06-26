using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingSite.Web.ViewModels
{
    public class HotelViewModel
    {
        public string City { get; set; }
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }
        public string HotelCode { get; set; }
        [Display(Name = "Star Rating")]
        public int StarRating { get; set; }
        [Display(Name = "Rooms")]
        public List<HotelRoomViewModel> HotelRooms { get; set; }
    }
}
