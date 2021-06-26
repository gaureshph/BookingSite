using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using BookingSite.Web.Models;
using Microsoft.AspNetCore.Mvc;
using BookingSite.Web.Constants;
using System.Collections.Generic;
using BookingSite.Web.ViewModels;
using BookingSite.Web.Repositories;
using BookingSite.Web.DomainModels;

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
            TempData[TempDataKeys.NoOfRooms] = searchViewModel.NoOfRooms;
            TempData[TempDataKeys.ChickInDate] = searchViewModel.ChickInDate;
            TempData[TempDataKeys.CheckOutDate] = searchViewModel.CheckOutDate;

            ValidateViewModel(searchViewModel);

            if (ModelState.IsValid)
            {
                var hotels = await _masterRepository.GetHotelsAsync(searchViewModel.City);

                var hotelsViewModel = hotels.Select(hotel => HotelDomainModelToViewModel(hotel)).ToList();

                foreach (var hotel in hotelsViewModel)
                {
                    hotel.HotelRooms = (await _masterRepository.GetHotelRoomsAsync(hotel.HotelCode)).Select(room => HotelRoomDomainModelToViewModel(room)).ToList();
                }

                return View(hotelsViewModel);
            }

            ViewBag.ListOfCities = await GetCitiesAsync();
            ViewBag.ListOfNoOfRoomsOptions = GetNoOfRoomsOptions();
            return View(Views.Search, searchViewModel);
        }

        public async Task<IActionResult> Booking(int hotelRoomId)
        {
            var bookingViewModel = new BookingViewModel();

            var hotel = await _masterRepository.GetHotelByHotelRoomAsync(hotelRoomId);
            var hotelRoom = await _masterRepository.GetHotelRoomAsync(hotelRoomId);

            bookingViewModel.ChickInDate = Convert.ToDateTime(TempData[TempDataKeys.ChickInDate]);
            bookingViewModel.NumberOfRooms = Convert.ToInt32(TempData[TempDataKeys.NoOfRooms]);
            bookingViewModel.CheckoutDate = Convert.ToDateTime(TempData[TempDataKeys.CheckOutDate]);

            bookingViewModel.Hotel = HotelDomainModelToViewModel(hotel);
            bookingViewModel.HotelRoom = HotelRoomDomainModelToViewModel(hotelRoom);

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

        private HotelViewModel HotelDomainModelToViewModel(Hotel hotel)
        {
            return new HotelViewModel
            {
                City = hotel.City,
                HotelName = hotel.HotelName,
                HotelCode = hotel.HotelCode,
                StarRating = hotel.StarRating,
                HotelRooms = new List<HotelRoomViewModel>()
            };
        }

        private HotelRoomViewModel HotelRoomDomainModelToViewModel(HotelRoom room)
        {
            return new HotelRoomViewModel
            {
                HotelCode = room.HotelCode,
                ID = room.ID,
                RoomType = room.RoomType,
                Tariff = room.Tariff
            };
        }

        private void ValidateViewModel(SearchViewModel searchViewModel)
        {
            if(searchViewModel.ChickInDate > searchViewModel.CheckOutDate)
            {
                ModelState.AddModelError("ChickInDate", "Check in date cannot be greater than the check out date");
            }
            if (searchViewModel.ChickInDate < DateTime.Now)
            {
                ModelState.AddModelError("ChickInDate", "Cannot search for past date");
            }
        }

        #endregion
    }
}
