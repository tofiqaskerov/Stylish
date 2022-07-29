using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stylish.Data;
using Stylish.Models;

namespace Stylish.Areas.Dashboard.Controllers
{   [Area("dashboard")]
    public class BannerController : Controller
    {
        private readonly AppDbContext _context;

        public BannerController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var banner = _context.Banners.FirstOrDefault();
            return View(banner);
        }

       [HttpGet]
        public ActionResult Details(int id)
        {
            if(id == null)
                return NotFound();

            var banner = _context.Banners.FirstOrDefault(x => x.Id == id);
            
            if(banner == null)
                return NotFound();

            return View(banner);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var banner = _context.Banners.FirstOrDefault();
            if (banner != null)
                return RedirectToAction("Index");

            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Banner banner, IFormFile NewPhoto )
        {
            var fileExtation = Path.GetExtension( NewPhoto.FileName );
            if(fileExtation != ".jpg")
            {
                ViewBag.PhotoError = "Yalniz jpg formati qebul olunur";
                return View();
            }
            string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img" , myPhoto);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                NewPhoto.CopyTo(stream);    
            };
            banner.PhotoURL = "Img/" + myPhoto;
            _context.Banners.Add(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BannerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var banner = _context.Banners.FirstOrDefault(x => x.Id == id);
            if (banner == null)
                return NotFound();

            return View(banner);
        }

        // POST: BannerController/Edit/5
        [HttpPost]
        public IActionResult Edit(Banner banner, IFormFile NewPhoto, string? oldPhoto)
        {
            if(NewPhoto != null)
            {
                var fileExtation = Path.GetExtension(NewPhoto.FileName);
                if( fileExtation != ".jpg")
                {
                    ViewBag.PhotoError = "Yalniz jpg formati qebul olunur";
                    return View();
                };
                string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", myPhoto);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    NewPhoto.CopyTo(stream);
                };
                banner.PhotoURL = "Img/" + myPhoto;
            }
            else
            {
                banner.PhotoURL = oldPhoto;
            }
           
            _context.Banners.Update(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BannerController/Delete/5
        public ActionResult Delete(int id)
        {
            var banner = _context.Banners.FirstOrDefault(x =>x.Id == id);
            if(banner == null)
                return RedirectToAction("Index");

            return View();
        }

        // POST: BannerController/Delete/5
        [HttpPost]
        public IActionResult Delete( Banner banner)
        {
            if (banner == null)
                return RedirectToAction("Index");

            _context.Banners.Remove(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
