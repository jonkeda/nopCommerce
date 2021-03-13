using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nop.Web.Prototype.Models;
using System.Diagnostics;

namespace Nop.Web.Prototype.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Calculate(VouwwandenModel model)
        {
            model.Price.Value = model.Length.Value + model.Width.Value;

            return Json(model);
        }
    }
}
