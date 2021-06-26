using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSite.Web.ViewModels
{
    public class BookingViewModel
    {
        public HotelViewModel Hotel { get; set; }
        [Display(Name = "Hotel Room")]
        public HotelRoomViewModel HotelRoom { get; set; }
        public int ID { get; set; }
        [Display(Name = "Booking Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Pax Name")]
        public string PaxName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string ContactPhone { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Check In Date")]
        public DateTime ChickInDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Check Out Date")]
        public DateTime CheckoutDate { get; set; }
        [Display(Name = "Number Of Rooms")]
        public int NumberOfRooms { get; set; }
    }
}
