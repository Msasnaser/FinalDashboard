using AutoMapper;
using feliciano.DAL.Data;
using feliciano.DAL.Model;
using feliciano.PL.Areas.Dashboard.ViewModels.BlogsVM;
using feliciano.PL.Areas.Dashboard.ViewModels.ServicesVM;
using feliciano.PL.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace feliciano.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BlogsController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BlogsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var blog = context.blogs.ToList();

            return View(mapper.Map<IEnumerable<IndexBlogVM>>(blog));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImageName = FilesSetting.UplodeFile(vm.Image, "BlogImages");
           var blogs= mapper.Map<Blog>(vm);
            context.Add(blogs);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var blog = context.blogs.Find(id);
            if (blog is null)
            {
                return NotFound();
            }

            return View(mapper.Map<DetailsBlogVM>(blog));
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var blog = context.blogs.Find(id);
            if (blog is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(blog.ImageName, "BlogImages");
            context.blogs.Remove(blog);
            context.SaveChanges();
            return Ok(new { message = "service daleted" });
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var blog = context.blogs.Find(id);
            if (blog is null)
            {
                return NotFound();
            }
            return View(mapper.Map<BlogVM>(blog));
        }
        
        [HttpPost]
        public IActionResult Edit(BlogVM vm)
        {
            var blog = context.blogs.Find(vm.Id);

            if (blog is null)
            {
                return NotFound();
            }

            // If the user doesn't edit the image, we ignore validation for Image
            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else {
                FilesSetting.DeleteFile(blog.ImageName, "BlogImages");
                vm.ImageName = FilesSetting.UplodeFile(vm.Image, "BlogImages");
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            if (vm.IsDeleted)
            {
                FilesSetting.DeleteFile(vm.ImageName, "BlogImages");
                context.Remove(blog); // Remove the blog if marked as deleted
            }
            else
            {
                mapper.Map(vm, blog); // Update the blog details if not deleted
            }

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }

}
