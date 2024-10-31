using AutoMapper;
using feliciano.DAL.Data;
using feliciano.DAL.Model;
using feliciano.PL.Areas.Dashboard.ViewModels.ServicesVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace feliciano.PL.Areas.Dashboard.Controllers
{
   
    [Area("Dashboard")]
    //[Authorize (Roles="Admin")]
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServiceController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
        //    if (!User.IsInRole("Admin"))
        //    {
        //        // Use RedirectToAction to navigate to Account/Login without an area
        //        return Redirect("/Account/Login");
        //    }


            var service = context.services.ToList();

            return View(mapper.Map<IEnumerable<IndexServiceVM>>(service));
        }
        [HttpGet]

        public IActionResult Create()
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    // Use RedirectToAction to navigate to Account/Login without an area
            //    return Redirect("/Account/Login");
            //}
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var service = mapper.Map<Service>(vm);
            context.Add(service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    // Use RedirectToAction to navigate to Account/Login without an area
            //    return Redirect("/Account/Login");
            //}
            if (id is null)
            {
                return BadRequest();
            }
            var service = context.services.Find(id);
            if (service is null)
            {
                return NotFound();
            }

            return View(mapper.Map<DetailsServiceVM>(service));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    // Use RedirectToAction to navigate to Account/Login without an area
            //    return Redirect("/Account/Login");
            //}
            if (id is null)
            {
                return BadRequest();
            }
            var service = context.services.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            return View(mapper.Map<ServiceVM>(service));
        }
        [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var service = context.services.Find(vm.Id);
            if(service is null)
            {
                return NotFound();
            }
            if (vm.IsDeleted)
            {
                // If the service is marked as deleted, remove it from the context
                context.Remove(service);
            }
            else
            {
                // Update service details if not deleted
                mapper.Map(vm, service);
            }
                context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        // (هاد الكود اللي رح يحولنا للصفحة اللي فيها كانسل او ديليت (صفحة التاكد
        //[HttpGet]
        //public IActionResult Delete(int? id) {

        //    if (id is null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    var service = context.services.Find(id);
        //    if (service is null)
        //    {
        //        return NotFound();
        //    }
        //    return View(mapper.Map<ServiceVM>(service));
        //}

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    // Use RedirectToAction to navigate to Account/Login without an area
            //    return Redirect("/Account/Login");
            //}
            var service = context.services.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof (Index));
            }
            context.services.Remove(service);
            context.SaveChanges();
            return Ok(new {message="service daleted"});
        }
    }
}
