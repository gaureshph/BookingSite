using System;

namespace BookingSite.Web.DomainModels
{
    public class HotelBooking
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string HotelName { get; set; }
        public string HotelCode { get; set; }
        public string RoomType { get; set; }
        public decimal Tariff { get; set; }
        public int NumberOfRooms { get; set; }
        public string PaxName { get; set; }
        public string ContactPhone { get; set; }
        public DateTime ChickInDate { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}
