using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSite.Web.ViewModels
{
    public class BookingViewModel
    {
        public HotelViewModel Hotel { get; set; }
        public HotelRoomViewModel HotelRoom { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string PaxName { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [DataType(DataType.Date)]
        public DateTime ChickInDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
