using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stylish.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]


    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
