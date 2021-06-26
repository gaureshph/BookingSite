using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingSite.Web.ViewModels;
using BookingSite.Web.Repositories;

namespace BookingSite.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingRepository.GetBookingsAsync();
            var bookingsViewModel = bookings.Select(booking => new BookingViewModel
            {
                CheckoutDate = booking.CheckoutDate,
                ChickInDate = booking.ChickInDate,
                ContactPhone = booking.ContactPhone,
                Date = booking.Date,
                Hotel = new HotelViewModel { HotelName = booking.HotelName },
                HotelRoom = new HotelRoomViewModel { RoomType = booking.RoomType, Tariff = booking.Tariff },
                ID = booking.ID,
                NumberOfRooms = booking.NumberOfRooms,
                PaxName = booking.PaxName                
            });

            return View(bookingsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(BookingViewModel bookingViewModel)
        {
            if (ModelState.IsValid)
            {
                bookingViewModel.Date = DateTime.Now;

                var bookingId = await _bookingRepository.AddBookingAsync(new DomainModels.HotelBooking
                {
                    CheckoutDate = bookingViewModel.CheckoutDate,
                    ChickInDate = bookingViewModel.ChickInDate,
                    ContactPhone = bookingViewModel.ContactPhone,
                    Date = bookingViewModel.Date,
                    HotelCode = bookingViewModel.Hotel.HotelCode,
                    HotelName = bookingViewModel.Hotel.HotelName,
                    NumberOfRooms = bookingViewModel.NumberOfRooms,
                    PaxName = bookingViewModel.PaxName,
                    RoomType = bookingViewModel.HotelRoom.RoomType,
                    Tariff = bookingViewModel.HotelRoom.Tariff
                });

                bookingViewModel.ID = bookingId;

                return View("BookingConfirmation", bookingViewModel);
            }

            return View("Booking", bookingViewModel);
        }
    }
}
