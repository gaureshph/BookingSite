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
        public HotelController(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task<IActionResult> Search()
        {
            ViewBag.ListOfCities = await GetCitiesAsync();
            ViewBag.ListOfNoOfRoomsOptions = GetNoOfRoomsOptions();
            return View();
        }

        public async Task<IActionResult> SearchResults(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                var searchResultViewModel = new SearchResultViewModel();

                searchResultViewModel.City = searchViewModel.City;
                searchResultViewModel.CheckInDate = searchViewModel.CheckInDate;
                searchResultViewModel.CheckOutDate = searchViewModel.CheckOutDate;
                searchResultViewModel.NoOfRooms = searchViewModel.NoOfRooms;
                var hotels = await _masterRepository.GetHotelsAsync(searchViewModel.City);

                searchResultViewModel.Hotels = hotels.Select(hotel => new HotelViewModel
                {
                    City = hotel.City,
                    HotelName = hotel.HotelName,
                    HotelCode = hotel.HotelCode,
                    StarRating = hotel.StarRating,
                    HotelRooms = new List<HotelRoomViewModel>()
                }).ToList();

                foreach (var hotel in searchResultViewModel.Hotels)
                {
                    hotel.HotelRooms = (await _masterRepository.GetHotelRoomsAsync(hotel.HotelCode)).Select(room => new HotelRoomViewModel
                    {
                        HotelCode = room.HotelCode,
                        ID = room.ID,
                        RoomType = room.RoomType,
                        Tariff = room.Tariff
                    }).ToList();
                }

                return View(searchResultViewModel);
            }

            ViewBag.ListOfCities = await GetCitiesAsync();
            ViewBag.ListOfNoOfRoomsOptions = GetNoOfRoomsOptions();
            return View("Search", searchViewModel);
        }

        public async Task<IActionResult> Booking(SearchResultViewModel searchResultViewModel)
        {
            ViewBag.ListOfCities = await GetCitiesAsync();
            ViewBag.ListOfNoOfRoomsOptions = GetNoOfRoomsOptions();
            return View();
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
