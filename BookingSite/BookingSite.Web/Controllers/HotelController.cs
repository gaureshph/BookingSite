using System.Diagnostics;
using BookingSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Web.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
