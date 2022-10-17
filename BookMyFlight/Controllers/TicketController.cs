using Microsoft.AspNetCore.Mvc;

namespace BookMyFlight.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Ticket()
        {
            return View();
        }
        public IActionResult Cancel()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
