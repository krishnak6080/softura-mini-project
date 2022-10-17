using Microsoft.AspNetCore.Mvc;
using BookMyFlight.Models;
namespace BookMyFlight.Controllers
{
    public class PaymentController : Controller
    {
        private readonly BookMyFlightContext db;
        private readonly ISession session;

        public PaymentController(BookMyFlightContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Payment(Payment p)
        {
            db.Payments.Add(p);
            db.SaveChanges();
            return RedirectToAction("Ticket", "Ticket");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
