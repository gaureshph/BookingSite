using System.ComponentModel.DataAnnotations;

namespace BookingSite.Web.ViewModels
{
    public class HotelRoomViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }
        public decimal Tariff { get; set; }
        public string HotelCode { get; set; }
    }
}
