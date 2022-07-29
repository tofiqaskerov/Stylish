using Microsoft.AspNetCore.Mvc;
using Stylish.Data;
using Stylish.Models;
using Stylish.ViewModel;
using System.Diagnostics;

namespace Stylish.Controllers
{  
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var banner = _context.Banners.FirstOrDefault();
            var about = _context.Abouts.FirstOrDefault();
            var callout = _context.Callouts.FirstOrDefault();
            var services = _context.Services.ToList();
            var portfolios = _context.Portfolios.ToList();
          
            HomeVm vm = new()
            {
                Banner = banner,
                About  = about,
                Services = services,
                Portfolios = portfolios,
                Callout = callout,
             
            };
            return View(vm);
        }



        
    }
}