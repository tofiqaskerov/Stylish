using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stylish.Data;
using Stylish.Models;

namespace Stylish.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
 

    public class CalloutController : Controller
    {
        private readonly AppDbContext _context;

        public CalloutController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var callout = _context.Callouts.FirstOrDefault();
            return View(callout);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == null)
                return NotFound();

            var callout = _context.Callouts.FirstOrDefault(x => x.Id == id);

            if (callout == null)
                return NotFound();

            return View(callout);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var callout = _context.Callouts.FirstOrDefault();
            if (callout != null)
                return RedirectToAction("Index");

            return View();
        }


        [HttpPost]
        public IActionResult Create(Callout callout, IFormFile NewPhoto)
        {
            var fileExtation = Path.GetExtension(NewPhoto.FileName);
            if(fileExtation != ".jpg")
            {
                ViewBag.PhotoError = "Yalniz jpg formati qebul olunur";
                return View();
            }
            string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", myPhoto);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                NewPhoto.CopyTo(stream);
            };
            callout.PhotoURL = "Img/" + myPhoto;
            _context.Callouts.Add(callout);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BannerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var callout = _context.Callouts.FirstOrDefault(x => x.Id == id);
            if (callout == null)
                return NotFound();

            return View(callout);
        }

        // POST: BannerController/Edit/5
        [HttpPost]
        public IActionResult Edit(Callout callout, IFormFile NewPhoto, string? oldPhoto)
        {
            if(NewPhoto != null)
            {
                var fileExtation = Path.GetExtension(NewPhoto.FileName);
                if (fileExtation != ".jpg")
                {
                    ViewBag.PhotoError = "Yalniz jpg formati qebul olunur";
                    return View();
                }
                string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", myPhoto);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    NewPhoto.CopyTo(stream);
                };
                callout.PhotoURL = "Img/" + myPhoto;
            }
            else
            {
                callout.PhotoURL = oldPhoto;
            }
            
            _context.Callouts.Update(callout);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BannerController/Delete/5
        public ActionResult Delete(int id)
        {
            var callout = _context.Callouts.FirstOrDefault(x => x.Id == id);
            if (callout == null)
                return RedirectToAction("Index");

            return View();
        }

        // POST: BannerController/Delete/5
        [HttpPost]
        public IActionResult Delete(Callout callout)
        {
            if (callout == null)
                return RedirectToAction("Index");

            _context.Callouts.Remove(callout);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
