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
        [Display(Name = "Check In Date")]
        public DateTime ChickInDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Check Out Date")]
        public DateTime CheckOutDate { get; set; }
        [Display(Name = "No Of Rooms")]
        public int NoOfRooms { get; set; }
        public List<HotelViewModel> Hotels { get; set; }
    }
}
