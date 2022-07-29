using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stylish.Data;
using Stylish.Models;

namespace Stylish.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();   
            return View(about);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if(id == null)
                return NotFound();

            var about = _context.Abouts.FirstOrDefault(x => x.Id == id);

            if (about == null)
                return NotFound();

            return View(about);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var abouts = _context.Abouts.FirstOrDefault();
            if (abouts != null)
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public ActionResult Create(About about)
        {
            if(about.Title == null || about.Subtitle ==null || about.BgColor ==null)
            {
                ViewBag.Error = "Bosluqlari doldurun!!!!";
                return View();
            }
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AboutController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            if (about == null)
                return NotFound();

            return View(about);
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        
        public IActionResult Edit(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AboutController/Delete/5
        public ActionResult Delete(int id)
        {
            var about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            if (about == null)
                return RedirectToAction("Index");

            return View();
        }

        // POST: AboutController/Delete/5
        [HttpPost]
        public IActionResult Delete(About about)
        {
            if (about == null)
                return RedirectToAction("Index");

            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
