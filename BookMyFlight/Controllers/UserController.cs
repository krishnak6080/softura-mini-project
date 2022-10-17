using Microsoft.AspNetCore.Mvc;
using BookMyFlight.Models;
namespace BookMyFlight.Controllers
{
    public class UserController : Controller
    {
        private readonly BookMyFlightContext db;
        private readonly ISession session;

        public UserController(BookMyFlightContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult login()

        {
            return View();
        }
        [HttpPost]

        public IActionResult Login(UserDatum t)
        {
            var result = (from i in db.UserData
                          where i.Email == t.Email && i.Password == t.Password
                          select i
                          ).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("Uname", t.Email);
                return RedirectToAction("Index","AvailableFlights");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserDatum e)
        {
            db.UserData.Add(e);
            db.SaveChanges();
            return RedirectToAction("Login");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("User");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
