using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using BookingSite.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookingSite.Web.ViewModels;
using BookingSite.Web.Repositories;

namespace BookingSite.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IMasterRepository _masterRepository;
        private readonly IBookingRepository _bookingRepository;
        public HotelController(IMasterRepository masterRepository, IBookingRepository bookingRepository)
        {
            _masterRepository = masterRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<IActionResult> Search()
        {
            ViewBag.ListOfCities = await GetCitiesAsync();
            ViewBag.ListOfNoOfRoomsOptions = GetNoOfRoomsOptions();
            return View();
        }

        public async Task<IActionResult> SearchResults(SearchViewModel searchViewModel)
        {
            TempData["NoOfRooms"] = searchViewModel.NoOfRooms;
            TempData["ChickInDate"] = searchViewModel.ChickInDate;
            TempData["CheckOutDate"] = searchViewModel.CheckOutDate;
            TempData["City"] = searchViewModel.City;

            if (ModelState.IsValid)
            {
                var hotels = await _masterRepository.GetHotelsAsync(searchViewModel.City);

                var hotelsViewModel = hotels.Select(hotel => new HotelViewModel
                {
                    City = hotel.City,
                    HotelName = hotel.HotelName,
                    HotelCode = hotel.HotelCode,
                    StarRating = hotel.StarRating,
                    HotelRooms = new List<HotelRoomViewModel>()
                }).ToList();

                foreach (var hotel in hotelsViewModel)
                {
                    hotel.HotelRooms = (await _masterRepository.GetHotelRoomsAsync(hotel.HotelCode)).Select(room => new HotelRoomViewModel
                    {
                        HotelCode = room.HotelCode,
                        ID = room.ID,
                        RoomType = room.RoomType,
                        Tariff = room.Tariff
                    }).ToList();
                }

                return View(hotelsViewModel);
            }

            ViewBag.ListOfCities = await GetCitiesAsync();
            ViewBag.ListOfNoOfRoomsOptions = GetNoOfRoomsOptions();
            return View("Search", searchViewModel);
        }

        public async Task<IActionResult> Booking(int hotelRoomId)
        {
            var bookingViewModel = new BookingViewModel();

            var hotel = await _masterRepository.GetHotelByHotelRoomAsync(hotelRoomId);
            var hotelRoom = await _masterRepository.GetHotelRoomAsync(hotelRoomId);

            bookingViewModel.ChickInDate = Convert.ToDateTime(TempData["ChickInDate"]);
            bookingViewModel.NumberOfRooms = Convert.ToInt32(TempData["NoOfRooms"]);
            bookingViewModel.CheckoutDate = Convert.ToDateTime(TempData["CheckOutDate"]);

            bookingViewModel.Hotel = new HotelViewModel();
            bookingViewModel.Hotel.City = hotel.City;
            bookingViewModel.Hotel.HotelCode = hotel.HotelCode;
            bookingViewModel.Hotel.HotelName = hotel.HotelName;
            bookingViewModel.Hotel.StarRating = hotel.StarRating;
            bookingViewModel.HotelRoom = new HotelRoomViewModel();
            bookingViewModel.HotelRoom.HotelCode = hotelRoom.HotelCode;
            bookingViewModel.HotelRoom.ID = hotelRoom.ID;
            bookingViewModel.HotelRoom.RoomType = hotelRoom.RoomType;
            bookingViewModel.HotelRoom.Tariff = hotelRoom.Tariff;

            return View(bookingViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region 
        private async Task<List<CityViewModel>> GetCitiesAsync()
        {
            var cities = await _masterRepository.GetCitiesAsync();
            return cities.Select(city => new CityViewModel
            {
                Name = city.Name
            }).ToList();
        }

        private List<NoOfRoomsOptionViewModel> GetNoOfRoomsOptions()
        {
            return _masterRepository.GetNoOfRoomsOptions().Select(option => new NoOfRoomsOptionViewModel
            {
                Option = option.Option
            }).ToList();
        }

        #endregion
    }
}
