using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stylish.Data;
using Stylish.Models;

namespace Stylish.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PortfolioController
        public ActionResult Index()
        {
            var portfolioCount = _context.Portfolios.Count();
            ViewBag.portfolioCount = portfolioCount;
            var portfolio  = _context.Portfolios.ToList();
            return View(portfolio);
        }

        // GET: PortfolioController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == null)
                return NotFound();

            var portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);

            if (portfolio == null)
                return NotFound();

            return View(portfolio);
        }

        // GET: PortfolioController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var portfolioCount = _context.Portfolios.Count();
            if (portfolioCount >= 6)
                return RedirectToAction("Index");

            return View();
        }

        // POST: PortfolioController/Create
        [HttpPost]
        public IActionResult Create(Portfolio portfolio, IFormFile NewPhoto)
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
            portfolio.PhotoURL = "Img/" + myPhoto;
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PortfolioController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio == null)
                return NotFound();

            return View(portfolio);
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
        public IActionResult Edit(Portfolio portfolio, IFormFile NewPhoto, string? oldPhoto)
        {
            if (NewPhoto != null)
            {
                var fileExtation = Path.GetExtension(NewPhoto.FileName);
                if (fileExtation != ".jpg")
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
                portfolio.PhotoURL = "Img/" + myPhoto;
            }
            else
            {
                portfolio.PhotoURL = oldPhoto;
            }

            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio == null)
                return RedirectToAction("Index");

            return View();
        }

        // POST: PortfolioController/Delete/5
        [HttpPost]
        public IActionResult Delete(Portfolio portfolio)
        {
            if (portfolio == null)
                return RedirectToAction("Index");

            _context.Portfolios.Remove(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
