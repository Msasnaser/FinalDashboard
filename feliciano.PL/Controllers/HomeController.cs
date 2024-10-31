using feliciano.DAL.Data;
using feliciano.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace feliciano.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }
	
		public IActionResult Index()
        {
            ViewData["slider"] = context.sliders.ToList();
            ViewData["items"] = context.items.ToList();
            ViewData["portfolio"] = context.portfolios.ToList();
            ViewData["service"]=context.services.ToList();
            ViewData["blog"] = context.blogs.ToList();
            return View();
        }

        public IActionResult Privacy()
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
