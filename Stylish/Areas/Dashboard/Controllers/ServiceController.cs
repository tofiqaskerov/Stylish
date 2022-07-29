using Microsoft.AspNetCore.Mvc;
using Stylish.Data;
using Stylish.Models;

namespace Stylish.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var serviceCount = _context.Services.Count();
            ViewBag.serviceCount = serviceCount;
            var service = _context.Services.ToList();
            return View(service);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == null)
                return NotFound();

            var service = _context.Services.FirstOrDefault(x => x.Id == id);

            if (service == null)
                return NotFound();

            return View(service);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var serviceCount = _context.Services.Count();
            if (serviceCount >= 8)
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {

            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AboutController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
                return NotFound();

            return View(service);
        }

        // POST: AboutController/Edit/5
        [HttpPost]

        public IActionResult Edit(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AboutController/Delete/5
        public ActionResult Delete(int id)
        {
            var service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
                return RedirectToAction("Index");

            return View();
        }

        // POST: AboutController/Delete/5
        [HttpPost]
        public IActionResult Delete(Service service)
        {
            if (service == null)
                return RedirectToAction("Index");

            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
