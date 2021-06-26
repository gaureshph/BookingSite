using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingSite.Web.ViewModels
{
    public class SearchResultViewModel
    {
        [Required]
        public string City { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }
        public int NoOfRooms { get; set; }
        public List<HotelViewModel> Hotels { get; set; }
    }
}
