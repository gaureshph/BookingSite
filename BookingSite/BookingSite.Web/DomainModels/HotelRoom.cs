namespace BookingSite.Web.DomainModels
{
    public class HotelRoom
    {
        public int ID { get; set; }
        public string RoomType { get; set; }
        public decimal Tariff { get; set; }
        public string HotelCode { get; set; }
        public Hotel Hotel { get; set; }
    }
}
