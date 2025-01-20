using Microsoft.AspNetCore.Mvc;

namespace TruckingDDD.Controllers
{
    public class TripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
