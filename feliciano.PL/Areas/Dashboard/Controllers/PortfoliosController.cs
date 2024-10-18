using AutoMapper;
using feliciano.DAL.Data;
using feliciano.DAL.Model;
using feliciano.PL.Areas.Dashboard.ViewModels.BlogsVM;
using feliciano.PL.Areas.Dashboard.ViewModels.PortfoliosVM;
using feliciano.PL.Areas.Dashboard.ViewModels.ServicesVM;
using feliciano.PL.Data.Migrations;
using feliciano.PL.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace feliciano.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PortfoliosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PortfoliosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var portfolio = context.portfolios.ToList();

            return View(mapper.Map<IEnumerable<PortfolioVM>>(portfolio));
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PortfolioVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var portfolio = mapper.Map<Portfolio>(vm);
            context.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var portfolio = context.portfolios.Find(id);
            if (portfolio is null)
            {
                return NotFound();
            }

            return View(mapper.Map<PortfolioVM>(portfolio));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var portfolio = context.portfolios.Find(id);
            if (portfolio is null)
            {
                return NotFound();
            }
            return View(mapper.Map<PortfolioVM>(portfolio));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PortfolioVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var portfolio = context.portfolios.Find(vm.Id);
            if (portfolio is null)
            {
                return NotFound();
            }
            mapper.Map(vm, portfolio);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var portfolio = context.portfolios.Find(id);
            if (portfolio is null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.portfolios.Remove(portfolio);
            context.SaveChanges();
            return Ok(new { message = "Portfolio Deleted" });
        }
    }
}
