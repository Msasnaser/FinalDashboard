using AutoMapper;
using feliciano.DAL.Data;
using feliciano.DAL.Model;
using feliciano.PL.Areas.Dashboard.ViewModels.BlogsVM;
using feliciano.PL.Areas.Dashboard.ViewModels.ItemsVM;
using feliciano.PL.Areas.Dashboard.ViewModels.PortfoliosVM;
using feliciano.PL.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace feliciano.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]

    public class ItemsController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ItemsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var items = context.items.Include(i => i.portfolio).ToList();
            var viewModel = items.Select(item => new IndexItemVM
            {
                Id = item.Id,
                ImageName = item.ImageName,
                PortfolioName = item.portfolio != null ? item.portfolio.Name : "No Portfolio"  // Handle null cases
            });

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var portfolio = context.portfolios.ToList();
            var vm = new ItemFormVM
            {
                //protfolios = mapper.Map<IEnumerable<PortfolioVM>>(portfolio)
                protfolios = new SelectList(portfolio, "Id", "Name")
        };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // Upload the image and set the ImageName
            vm.ImageName = FilesSetting.UplodeFile(vm.Image, "ItemImages");

            // Map the ViewModel to the Item entity
            var item = mapper.Map<Item>(vm);
            context.Add(item);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

 
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var item = context.items.Find(id);
            if (item is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(item.ImageName, "ItemImages");
            context.items.Remove(item);
            context.SaveChanges();
            return Ok(new { message = "Item deleted" });
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var item = context.items.Include(i => i.portfolio).FirstOrDefault(i => i.Id == id);

            if (item is null)
            {
                return NotFound();
            }
            // dont use autto mapper to ensure the Portfolio Name is mapped
            var viewModel = new IndexItemVM
            {
                Id = item.Id,
                ImageName = item.ImageName,
                CreatedTime = item.CreatedTime,
                PortfolioName = item.portfolio != null ? item.portfolio.Name : "No Portfolio" // Handle null portfolio
            };

            return View(viewModel);
        } 
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var item = context.items.Find(id.Value);
            if (item is null)
            {
                return NotFound();
            }

            // Fetch the list of portfolios to populate the SelectList
            var viewModel = mapper.Map<ItemFormVM>(item);
            viewModel.protfolios = new SelectList(context.portfolios, "Id", "Name"); // Preselect the current portfolio

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemFormVM vm)
        {
            var item= context.items.Find(vm.Id);
            if (item is null)
            {
                return NotFound();
            }
            // If the user doesn't edit the image, we ignore validation for Image
            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(item.ImageName, "ItemImages");
                vm.ImageName = FilesSetting.UplodeFile(vm.Image, "ItemImages");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mapper.Map(vm, item);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
