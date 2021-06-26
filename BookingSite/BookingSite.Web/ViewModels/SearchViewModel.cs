using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSite.Web.ViewModels
{
    public class SearchViewModel
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
    }
}
