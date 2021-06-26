using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSite.Web.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        public string City { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }
        public int NoOfRooms { get; set; }
    }
}
