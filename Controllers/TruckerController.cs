using Microsoft.AspNetCore.Mvc;

namespace TruckingDDD.Controllers
{
    public class TruckerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
