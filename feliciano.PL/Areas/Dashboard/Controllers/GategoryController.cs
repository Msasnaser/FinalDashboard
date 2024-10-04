using Microsoft.AspNetCore.Mvc;

namespace feliciano.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class GategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
