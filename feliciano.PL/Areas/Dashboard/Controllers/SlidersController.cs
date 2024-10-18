using AutoMapper;
using feliciano.DAL.Data;
using feliciano.DAL.Model;
using feliciano.PL.Areas.Dashboard.ViewModels.BlogsVM;
using feliciano.PL.Areas.Dashboard.ViewModels.ItemsVM;
using feliciano.PL.Areas.Dashboard.ViewModels.SlidersVM;
using feliciano.PL.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace feliciano.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SlidersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SlidersController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var slider = context.sliders.ToList();

            return View(mapper.Map<IEnumerable<SliderVM>>(slider));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SliderVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImageName = FilesSetting.UplodeFile(vm.Image, "SliderImages");

            // Map the ViewModel to the Item entity
            var slider = mapper.Map<Slider>(vm);
            context.Add(slider);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var slider = context.sliders.Find(id);
            if (slider is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(slider.ImageName, "SliderImages");
            context.sliders.Remove(slider);
            context.SaveChanges();
            return Ok(new { message = "Slider  deleted" });
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var slider = context.sliders.Find(id.Value);

            if (slider is null)
            {
                return NotFound();
            }
            return View(mapper.Map<SliderDetailsVM>(slider));
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var slider = context.sliders.Find(id.Value);
            if (slider is null)
            {
                return NotFound();
            }

            return View(mapper.Map<SliderVM>(slider));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SliderVM vm)
        {
            var slider = context.sliders.Find(vm.Id);
            if (slider is null)
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
                FilesSetting.DeleteFile(slider.ImageName, "SliderImages");
                vm.ImageName = FilesSetting.UplodeFile(vm.Image, "SliderImages");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mapper.Map(vm, slider);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
